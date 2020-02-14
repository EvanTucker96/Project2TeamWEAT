alter table Packages
add PkgImageFile varchar(30) null

UPDATE dbo.Packages set [PkgImageFile] = 'caribbean.jpg' where [PackageId] = 1
UPDATE dbo.Packages set [PkgImageFile] = 'hawaii.jfif' where [PackageId] = 2
UPDATE dbo.Packages set [PkgImageFile] = 'asia.jpg' where [PackageId] = 3
UPDATE dbo.Packages set [PkgImageFile] = 'Europe.jpg' where [PackageId] = 4

UPDATE dbo.Packages set [PkgStartDate] = '2020-12-25', [PkgEndDate] = '2021-01-04' where [PackageId] = 1
UPDATE dbo.Packages set [PkgStartDate] = '2020-12-12', [PkgEndDate] = '2020-12-20' where [PackageId] = 2
UPDATE dbo.Packages set [PkgStartDate] = '2020-05-14', [PkgEndDate] = '2020-05-28' where [PackageId] = 3
UPDATE dbo.Packages set [PkgStartDate] = '2020-11-01', [PkgEndDate] = '2020-11-14' where [PackageId] = 4
