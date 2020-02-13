alter table customers
alter column
custbusphone nvarchar(20) null

alter table Customers 
add Password varchar(128) not null default '$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'

update Agents set password='$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'

alter table Agents
alter column Password varchar(128)