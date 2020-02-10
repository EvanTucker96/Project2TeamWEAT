
Use Marina

create view avilableSlips
as
SELECT ID, Width, Length, DockID FROM Slip WHERE (ID NOT IN (SELECT SlipID FROM Lease))

alter table [Customer] add [EMail] varchar(128)
alter table [Customer] add [Password] varchar(512)
alter table [Customer] add [Salt] varchar(512)
