CREATE PROCEDURE dbo.pr_FindProductVersionsOptional
  (
	@productName nvarchar(255) = null,
	@productVersionName nvarchar(255) = null,
    @minVolume float = null,
    @maxVolume float = null
  )
AS

if @productName is not null
	set @productName = '%' + @productName + '%';
	
if @productVersionName is not null
	set @productVersionName = '%' + @productVersionName + '%';

declare @nsql nvarchar(max)
set @nsql = 
'
SELECT
	ver.ID		as [VersionID],
	prod.Name	as [ProductName],
	ver.Name	as [VersionName],
	ver.Width,
	ver.Length,
	ver.Height
FROM dbo.ProductVersion ver
	INNER JOIN dbo.Product prod on prod.ID = ver.ProductID
WHERE 1 = 1
'

if @productVersionName is not null
	set @nsql += ' and ver.Name like @productVersionName';

if @productName is not null
	set @nsql += ' and ver.Name like @productName';

if @minVolume is not null
	set @nsql += ' and ver.Width * ver.Length * ver.Height >= @minVolume';

if @maxVolume is not null
	set @nsql += ' and ver.Width * ver.Length * ver.Height <= @maxVolume';

execute sp_executesql @nsql, 
	N'@productVersionName nvarchar(255), @productName nvarchar(255), @minVolume float, @maxVolume float', 
	@productVersionName=@productVersionName, 
	@productName=@productName, 
	@minVolume=@minVolume, 
	@maxVolume=@maxVolume