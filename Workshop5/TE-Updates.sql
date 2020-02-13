/* Make BusPhone not required */
alter table customers
alter column
custbusphone nvarchar(20) null

/* add Password to  Customers */
alter table Customers 
add Password varchar(128) not null default '$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'



/* If Password column does exist in Agents, increase size from 50
and set a default 'password' */
alter table Agents
alter column Password varchar(128)
update Agents set password='$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'

/* If Password column does not exist in Agents */
alter table Agents 
add Password varchar(128) not null default '$2a$11$P7OHmF7BN95z56SkArdWI.SHEvsoJaeqzg1YFobDUP.saDAix6npi'