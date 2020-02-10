
Use Marina

create view avilableSlips
as
SELECT ID, Width, Length, DockID FROM Slip WHERE (ID NOT IN (SELECT SlipID FROM Lease))

alter table customer
add password varchar(512)

alter table customer	
add Email varchar(512)

alter table customer	
add Salt varchar(512)
