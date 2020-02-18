/* Make BusPhone not required */
alter table customers
alter column
custbusphone nvarchar(20) null

/* add Password to  Customers */
alter table Customers 
add Password varchar(128) not null default '$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'

/* Update existing customers Password column*/
update Customers set password='$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'


/* If Password column does exist in Agents, increase size from 50
and set a default 'password' */
alter table Agents
alter column Password varchar(128)
update Agents set password='$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'

/* If Password column does not exist in Agents */
alter table Agents 
add Password varchar(128) not null default '$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'

/* update packages to allow for image files */
alter table Packages
add PkgImageFile varchar(30) null
​
UPDATE dbo.Packages set [PkgImageFile] = 'caribbean.jpg' where [PackageId] = 1
UPDATE dbo.Packages set [PkgImageFile] = 'hawaii.jfif' where [PackageId] = 2
UPDATE dbo.Packages set [PkgImageFile] = 'asia.jpg' where [PackageId] = 3
UPDATE dbo.Packages set [PkgImageFile] = 'Europe.jpg' where [PackageId] = 4
​
UPDATE dbo.Packages set [PkgStartDate] = '2020-12-25', [PkgEndDate] = '2021-01-04' where [PackageId] = 1
UPDATE dbo.Packages set [PkgStartDate] = '2020-12-12', [PkgEndDate] = '2020-12-20' where [PackageId] = 2
UPDATE dbo.Packages set [PkgStartDate] = '2020-05-14', [PkgEndDate] = '2020-05-28' where [PackageId] = 3
UPDATE dbo.Packages set [PkgStartDate] = '2020-11-01', [PkgEndDate] = '2020-11-14' where [PackageId] = 4