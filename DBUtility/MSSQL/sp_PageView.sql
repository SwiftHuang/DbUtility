USE [HPMIS]
GO
/****** 对象:  StoredProcedure [dbo].[sp_PageView]    脚本日期: 06/15/2009 11:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[sp_PageView]
@tbname     sysname,           	--要分页显示的表名
@FieldKey   nvarchar(1000),  	--用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
@PageCurrent int=1,           	--要显示的页码
@PageSize   int=10,            	--每页的大小(记录数)
@FieldShow nvarchar(1000)='',  	--以逗号分隔的要显示的字段列表,如果不指定,则显示所有字段
@FieldOrder nvarchar(1000)='',  --以逗号分隔的排序字段列表,可以指定在字段后面指定DESC/ASC用于指定排序顺序
@Where    nvarchar(1000)='', 	--查询条件
@_RecordCount int OUTPUT        --记录总数
AS
SET NOCOUNT ON

IF OBJECT_ID(@tbname) IS NULL
BEGIN
	RAISERROR(N'对象"%s"不存在',1,16,@tbname)
	RETURN
END
IF OBJECTPROPERTY(OBJECT_ID(@tbname),N'IsTable')=0
	AND OBJECTPROPERTY(OBJECT_ID(@tbname),N'IsView')=0
	AND OBJECTPROPERTY(OBJECT_ID(@tbname),N'IsTableFunction')=0
BEGIN
	RAISERROR(N'"%s"不是表、视图或者表值函数',1,16,@tbname)
	RETURN
END


IF ISNULL(@FieldKey,N'')=''
BEGIN
	RAISERROR(N'分页处理需要主键（或者惟一键）',1,16)
	RETURN
END


IF ISNULL(@PageCurrent,0)<1 SET @PageCurrent=1
IF ISNULL(@PageSize,0)<1 SET @PageSize=10
IF ISNULL(@FieldShow,N'')=N'' SET @FieldShow=N'*'
IF ISNULL(@FieldOrder,N'')=N''
	SET @FieldOrder=N''
ELSE
	SET @FieldOrder=N'ORDER BY '+LTRIM(@FieldOrder)
IF ISNULL(@Where,N'')=N''
	SET @Where=N''
ELSE
	SET @Where=N'WHERE ('+@Where+N')'

IF @_RecordCount IS NULL
BEGIN
	DECLARE @sql nvarchar(4000)
	SET @sql=N'SELECT @_RecordCount=COUNT(1)'
		+N' FROM '+@tbname
		+N' '+@Where
	EXEC sp_executesql @sql,N'@_RecordCount int OUTPUT',@_RecordCount OUTPUT
	--SET @_RecordCount=(@_RecordCount+@PageSize-1)/@PageSize
END

DECLARE @TopN varchar(20),@TopN1 varchar(20)
SELECT @TopN=@PageSize,
	@TopN1=(@PageCurrent-1)*@PageSize

--第一页直接显示
IF @PageCurrent=1
	EXEC(N'SELECT TOP '+@TopN
		+N' '+@FieldShow
		+N' FROM '+@tbname
		+N' '+@Where
		+N' '+@FieldOrder)
ELSE
BEGIN
	--处理别名
	IF @FieldShow=N'*'
		SET @FieldShow=N'a.*'

	--生成主键(惟一键)处理条件
	DECLARE @Where1 nvarchar(4000),@Where2 nvarchar(4000),
		@s nvarchar(1000),@Field sysname
	SELECT @Where1=N'',@Where2=N'',@s=@FieldKey
	WHILE CHARINDEX(N',',@s)>0
		SELECT @Field=LEFT(@s,CHARINDEX(N',',@s)-1),
			@s=STUFF(@s,1,CHARINDEX(N',',@s),N''),
			@Where1=@Where1+N' AND a.'+@Field+N'=b.'+@Field,
			@Where2=@Where2+N' AND b.'+@Field+N' IS NULL',
			@Where=REPLACE(@Where,@Field,N'a.'+@Field),
			@FieldOrder=REPLACE(@FieldOrder,@Field,N'a.'+@Field),
			@FieldShow=REPLACE(@FieldShow,@Field,N'a.'+@Field)
	SELECT @Where=REPLACE(@Where,@s,N'a.'+@s),
		@FieldOrder=REPLACE(@FieldOrder,@s,N'a.'+@s),
		@FieldShow=REPLACE(@FieldShow,@s,N'a.'+@s),
		@Where1=STUFF(@Where1+N' AND a.'+@s+N'=b.'+@s,1,5,N''),	
		@Where2=CASE
			WHEN @Where='' THEN N'WHERE ('
			ELSE @Where+N' AND ('
			END+N'b.'+@s+N' IS NULL'+@Where2+N')'

	--执行查询
	EXEC(N'SELECT TOP '+@TopN
		+N' '+@FieldShow
		+N' FROM '+@tbname
		+N' a LEFT JOIN(SELECT TOP '+@TopN1
		+N' '+@FieldKey
		+N' FROM '+@tbname
		+N' a '+@Where
		+N' '+@FieldOrder
		+N')b ON '+@Where1
		+N' '+@Where2
		+N' '+@FieldOrder)
END



