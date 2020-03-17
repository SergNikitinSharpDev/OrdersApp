IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'GroupOrdersByAddressAndCategory'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.procname
GO

CREATE TYPE IDList
AS TABLE
(
  ID INT
);
GO

CREATE PROC GroupOrdersByAddressAndCategory
	@list as IDList READONLY
AS
BEGIN
	SET NOCOUNT ON
	  select o.Id, o.FirstName, o.LastName, o.Address, o.City, o.State, o.Country, p.SKU, tp.Quantity, g.ShipmentId 
		from TestOrders o
		inner join TestOrderProducts tp on o.Id = tp.OrderId
		inner join TestProductCategories t on tp.ProductId = t.ProductId
		inner join TestProducts p on tp.ProductId = p.id
		inner join (
	  select DENSE_RANK() OVER (ORDER BY [Address], City, [State], Country, CategoryId) as ShipmentId, 
			[Address], City, [State], Country, CategoryId from TestOrders o
		inner join TestOrderProducts tp on o.Id = tp.OrderId
		inner join TestProductCategories tpc on tp.ProductId = tpc.ProductId
		where o.id in (select ID from @list)
		group by [Address], City, [State], Country, CategoryId
		) g on 
			t.CategoryId = g.CategoryId and o.Address = g.Address and o.City = g.City and o.State = g.State and o.Country = g.Country
		where o.id in (select ID from @list)
END
GO