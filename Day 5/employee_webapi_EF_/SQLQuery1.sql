﻿create table employeeDetails
(
	empNo int primary key,
	empName varchar(20),
	empDesignation varchar(20),
	empSalary int,
	empIsPermenant bit
)

insert into employeeDetails values(101,'Nikhil','Consultant',3000,1)
insert into employeeDetails values(102,'Karan','Consultant',13000,1)
insert into employeeDetails values(103,'Mohan','Sales',23000,0)
insert into employeeDetails values(104,'Rohan','Consultant',4000,1)
insert into employeeDetails values(105,'Priya','Consultant',7000,0)
insert into employeeDetails values(106,'Riya','Sales',6000,1)
insert into employeeDetails values(107,'Jiya','Consultant',9000,0)
insert into employeeDetails values(108,'Diya','HR',12000,1)

select * from employeeDetails


alter table employeeDetails add empDeptno int
update employeeDetails set empDeptno = 20 where empDesignation = 'Consultant'

update employeeDetails set empDeptno = 10 where empDesignation = 'HR'

update employeeDetails set empDeptno = 30 where empDesignation = 'Sales'


create table deptInfo
(
	deptNo int primary key,
	deptName varchar(20),
	deptLocation varchar(20)
)

insert into deptInfo values(10,'HR','Chennai')
insert into deptInfo values(20,'Consultancy','New York')
insert into deptInfo values(30,'Sales','Mumbai')







