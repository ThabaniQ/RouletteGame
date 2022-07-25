

CREATE PROCEDURE pr_GetOrderSummary
 @StartDate date,	
 @EndDate date,
 @EmployeeID BIGINT,
 @CustomerID VARCHAR(50)

AS
select emp.titleofcourtesy,emp.firstname,emp.lastname ,ship.companyname, cus.companyName,ord.NumberOfOders,ord.date, ord.TotalFreightCost,ord.NumberOfDifferentProducts,ord.TotalOrderValue
from Employee as emp
inner join Orders as ord on @EmployeeID=ord.employee_id
inner join Shipper as ship on  ord.shipper_id=ship.id 
inner join Customer as cus on @CustomerID=cus.id
where ord.order_date = @StartDate or ord.order_date = @EndDate;