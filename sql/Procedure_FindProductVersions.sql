CREATE PROCEDURE dbo.pr_FindProductVersions
  (
	@productName nvarchar(255),
	@productVersionName nvarchar(255),
    @minVolume float,
    @maxVolume float
  )
AS

set @productName = '%' + @productName + '%';
set @productVersionName = '%' + @productVersionName + '%';

SELECT
	ver.ID		as [VersionID],
	prod.Name	as [ProductName],
	ver.Name	as [VersionName],
	ver.Width,
	ver.Length,
	ver.Height
FROM dbo.ProductVersion ver
	INNER JOIN dbo.Product prod on prod.ID = ver.ProductID
WHERE 
	ver.Name like @productVersionName and
	prod.Name like @productName and
	ver.Width * ver.Length * ver.Height >= @minVolume and
	ver.Width * ver.Length * ver.Height <= @maxVolume
