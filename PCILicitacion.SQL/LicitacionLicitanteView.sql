USE PCILicitacion
GO
--CREATE VIEW LicitacionLicitanteView
--AS
--SELECT Licitacion.Id AS LicitacionId
--	, Licitacion.LicitadorId, LicitadorEmpresa.Nombre AS LicitadorNombre
--	, LicitacionPartidas.ProductoId, Producto.Nombre AS ProductoNombre
--	, LicitacionPartidaMarcas.ProductoMarcaId, ProductoMarca.Nombre AS ProductoMarca
--	, LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre AS LicitanteNombre
--FROM Licitacion 
--	INNER JOIN LicitacionPartidas ON Licitacion.Id = LicitacionPartidas.LicitacionId 
--	INNER JOIN LicitacionPartidaMarcas ON LicitacionPartidas.Id = LicitacionPartidaMarcas.LicitacionPartidaId 
--	INNER JOIN Licitador ON Licitacion.LicitadorId = Licitador.Id 
--	INNER JOIN Empresa AS LicitadorEmpresa ON Licitador.Id = LicitadorEmpresa.Id 
--	INNER JOIN Producto ON LicitacionPartidas.ProductoId = Producto.Id 
--	INNER JOIN ProductoMarca ON LicitacionPartidaMarcas.ProductoMarcaId = ProductoMarca.Id 
--	LEFT OUTER JOIN LicitanteProductoMarca ON LicitacionPartidas.ProductoId = LicitanteProductoMarca.ProductoId AND 
--		LicitacionPartidaMarcas.ProductoMarcaId = LicitanteProductoMarca.ProductoMarcaId 
--	LEFT OUTER JOIN Licitante ON LicitanteProductoMarca.LicitanteId = Licitante.Id 
--	LEFT OUTER JOIN Empresa AS LicitanteEmpresa ON Licitante.Id = LicitanteEmpresa.Id

CREATE VIEW LicitanteLicitacionView
AS
SELECT Licitacion.Id AS LicitacionId, Licitacion.Nombre AS LicitacionNombre
	, Licitacion.LicitadorId, LicitadorEmpresa.Nombre AS LicitadorNombre
	, Licitacion.FechaCreacion, Licitacion.FechaCierre, Licitacion.FechaAdjudicacion
	, Licitacion.Observaciones
	, LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre AS LicitanteNombre
FROM Licitacion 
	INNER JOIN LicitacionPartidas ON Licitacion.Id = LicitacionPartidas.LicitacionId 
	INNER JOIN LicitacionPartidaMarcas ON LicitacionPartidas.Id = LicitacionPartidaMarcas.LicitacionPartidaId 
	INNER JOIN Licitador ON Licitacion.LicitadorId = Licitador.Id 
	INNER JOIN Empresa AS LicitadorEmpresa ON Licitador.Id = LicitadorEmpresa.Id 
	LEFT OUTER JOIN LicitanteProductoMarca ON LicitacionPartidas.ProductoId = LicitanteProductoMarca.ProductoId AND 
		LicitacionPartidaMarcas.ProductoMarcaId = LicitanteProductoMarca.ProductoMarcaId 
	LEFT OUTER JOIN Licitante ON LicitanteProductoMarca.LicitanteId = Licitante.Id 
	LEFT OUTER JOIN Empresa AS LicitanteEmpresa ON Licitante.Id = LicitanteEmpresa.Id1
GROUP BY Licitacion.Id, Licitacion.Nombre
	, Licitacion.LicitadorId, LicitadorEmpresa.Nombre
	, Licitacion.FechaCreacion, Licitacion.FechaCierre, Licitacion.FechaAdjudicacion
	, Licitacion.Observaciones
	, LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre

CREATE VIEW LicitanteLicitacionPartidaView
AS
SELECT LicitacionPartidas.Id AS LicitacionPartidaId
	, Licitacion.Id AS LicitacionId, Licitacion.LicitadorId, LicitadorEmpresa.Nombre AS LicitadorNombre
	, LicitacionPartidas.ProductoId, Producto.Nombre AS ProductoNombre, LicitacionPartidas.Cantidad AS ProductoCantidad, LicitacionPartidas.Observaciones AS ProductoObservaciones
	, LicitacionPartidaMarcas.ProductoMarcaId, ProductoMarca.Nombre AS ProductoMarca
	, LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre AS LicitanteNombre
FROM Licitacion 
	INNER JOIN LicitacionPartidas ON Licitacion.Id = LicitacionPartidas.LicitacionId 
	INNER JOIN LicitacionPartidaMarcas ON LicitacionPartidas.Id = LicitacionPartidaMarcas.LicitacionPartidaId 
	INNER JOIN Licitador ON Licitacion.LicitadorId = Licitador.Id 
	INNER JOIN Empresa AS LicitadorEmpresa ON Licitador.Id = LicitadorEmpresa.Id 
	INNER JOIN Producto ON LicitacionPartidas.ProductoId = Producto.Id 
	INNER JOIN ProductoMarca ON LicitacionPartidaMarcas.ProductoMarcaId = ProductoMarca.Id 
	LEFT OUTER JOIN LicitanteProductoMarca ON LicitacionPartidas.ProductoId = LicitanteProductoMarca.ProductoId AND 
		LicitacionPartidaMarcas.ProductoMarcaId = LicitanteProductoMarca.ProductoMarcaId 
	LEFT OUTER JOIN Licitante ON LicitanteProductoMarca.LicitanteId = Licitante.Id 
	LEFT OUTER JOIN Empresa AS LicitanteEmpresa ON Licitante.Id = LicitanteEmpresa.Id

CREATE VIEW LicitanteLicitacionPartidaProducto
SELECT        dbo.LicitanteProductoMarca.LicitanteId, dbo.Empresa.Nombre AS Licitante, dbo.LicitacionPartidaProducto.LicitacionPartidaId, dbo.LicitacionPartidaProducto.ProductoId, dbo.Producto.Nombre AS ProductoNombre, 
                         dbo.LicitacionPartidaProducto.Cantidad, dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId, dbo.ProductoMarca.Nombre AS ProductoMarca
FROM            dbo.LicitacionPartidaProducto INNER JOIN
                         dbo.LicitacionPartidaProductoMarcas ON dbo.LicitacionPartidaProducto.Id = dbo.LicitacionPartidaProductoMarcas.LicitacionPartidaProductoId INNER JOIN
                         dbo.LicitanteProductoMarca ON dbo.LicitacionPartidaProducto.ProductoId = dbo.LicitanteProductoMarca.ProductoId AND 
                         dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.LicitanteProductoMarca.ProductoMarcaId INNER JOIN
                         dbo.Producto ON dbo.LicitacionPartidaProducto.ProductoId = dbo.Producto.Id INNER JOIN
                         dbo.ProductoMarca ON dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.ProductoMarca.Id INNER JOIN
                         dbo.Empresa ON dbo.LicitanteProductoMarca.LicitanteId = dbo.Empresa.Id


ALTER VIEW LicitanteLicitacionView
AS
SELECT dbo.LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre AS LicitanteNombre
	, dbo.Licitacion.LicitadorId, LicitadorEmpresa.Nombre AS LicitadorNombre
	, dbo.LicitacionPartida.LicitacionId, dbo.Licitacion.Nombre AS LicitacionNombre, dbo.Licitacion.Observaciones
	, dbo.Licitacion.FechaCreacion, dbo.Licitacion.FechaCierre, dbo.Licitacion.FechaAdjudicacion
FROM            dbo.LicitacionPartidaProducto INNER JOIN
                         dbo.LicitacionPartidaProductoMarcas ON dbo.LicitacionPartidaProducto.Id = dbo.LicitacionPartidaProductoMarcas.LicitacionPartidaProductoId INNER JOIN
                         dbo.LicitanteProductoMarca ON dbo.LicitacionPartidaProducto.ProductoId = dbo.LicitanteProductoMarca.ProductoId AND 
                         dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.LicitanteProductoMarca.ProductoMarcaId INNER JOIN
                         dbo.Producto ON dbo.LicitacionPartidaProducto.ProductoId = dbo.Producto.Id INNER JOIN
                         dbo.ProductoMarca ON dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.ProductoMarca.Id INNER JOIN
                         dbo.Empresa AS LicitanteEmpresa ON dbo.LicitanteProductoMarca.LicitanteId = LicitanteEmpresa.Id INNER JOIN
                         dbo.LicitacionPartida ON dbo.LicitacionPartidaProducto.LicitacionPartidaId = dbo.LicitacionPartida.Id INNER JOIN
                         dbo.Licitacion ON dbo.LicitacionPartida.LicitacionId = dbo.Licitacion.Id INNER JOIN
                         dbo.Licitador ON dbo.Licitacion.LicitadorId = dbo.Licitador.Id INNER JOIN
                         dbo.Empresa AS LicitadorEmpresa ON dbo.Licitador.Id = LicitadorEmpresa.Id
GROUP BY dbo.LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre 
	, dbo.Licitacion.LicitadorId, LicitadorEmpresa.Nombre
	, dbo.LicitacionPartida.LicitacionId, dbo.Licitacion.Nombre, dbo.Licitacion.Observaciones
	, dbo.Licitacion.FechaCreacion, dbo.Licitacion.FechaCierre, dbo.Licitacion.FechaAdjudicacion

CREATE VIEW LicitacionPartidaView
AS
SELECT        dbo.LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre AS Licitante, dbo.Licitacion.LicitadorId, LicitadorEmpresa.Nombre AS Licitador, dbo.LicitacionPartida.LicitacionId, 
                         dbo.LicitacionPartidaProducto.LicitacionPartidaId
FROM            dbo.LicitacionPartidaProducto INNER JOIN
                         dbo.LicitacionPartidaProductoMarcas ON dbo.LicitacionPartidaProducto.Id = dbo.LicitacionPartidaProductoMarcas.LicitacionPartidaProductoId INNER JOIN
                         dbo.LicitanteProductoMarca ON dbo.LicitacionPartidaProducto.ProductoId = dbo.LicitanteProductoMarca.ProductoId AND 
                         dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.LicitanteProductoMarca.ProductoMarcaId INNER JOIN
                         dbo.Producto ON dbo.LicitacionPartidaProducto.ProductoId = dbo.Producto.Id INNER JOIN
                         dbo.ProductoMarca ON dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.ProductoMarca.Id INNER JOIN
                         dbo.Empresa AS LicitanteEmpresa ON dbo.LicitanteProductoMarca.LicitanteId = LicitanteEmpresa.Id INNER JOIN
                         dbo.LicitacionPartida ON dbo.LicitacionPartidaProducto.LicitacionPartidaId = dbo.LicitacionPartida.Id INNER JOIN
                         dbo.Licitacion ON dbo.LicitacionPartida.LicitacionId = dbo.Licitacion.Id INNER JOIN
                         dbo.Licitador ON dbo.Licitacion.LicitadorId = dbo.Licitador.Id INNER JOIN
                         dbo.Empresa AS LicitadorEmpresa ON dbo.Licitador.Id = LicitadorEmpresa.Id
GROUP BY  dbo.LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre, dbo.Licitacion.LicitadorId, LicitadorEmpresa.Nombre, dbo.LicitacionPartida.LicitacionId, 
                         dbo.LicitacionPartidaProducto.LicitacionPartidaId

ALTER VIEW LicitacionPartidaProductoView
AS
SELECT        dbo.LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre AS Licitante, dbo.Licitacion.LicitadorId, LicitadorEmpresa.Nombre AS Licitador, dbo.LicitacionPartida.LicitacionId, 
                         dbo.LicitacionPartidaProducto.LicitacionPartidaId, dbo.LicitacionPartidaProducto.Id AS LicitacionPartidaProductoId, dbo.LicitacionPartidaProducto.ProductoId, dbo.Producto.Nombre AS ProductoNombre, 
                         dbo.LicitacionPartidaProducto.Cantidad AS ProductoCantidad, dbo.LicitacionPartidaProducto.Observaciones AS ProductoObservaciones, dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId, 
                         dbo.ProductoMarca.Nombre AS ProductoMarca
FROM            dbo.LicitacionPartidaProducto INNER JOIN
                         dbo.LicitacionPartidaProductoMarcas ON dbo.LicitacionPartidaProducto.Id = dbo.LicitacionPartidaProductoMarcas.LicitacionPartidaProductoId INNER JOIN
                         dbo.LicitanteProductoMarca ON dbo.LicitacionPartidaProducto.ProductoId = dbo.LicitanteProductoMarca.ProductoId AND 
                         dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.LicitanteProductoMarca.ProductoMarcaId INNER JOIN
                         dbo.Producto ON dbo.LicitacionPartidaProducto.ProductoId = dbo.Producto.Id INNER JOIN
                         dbo.ProductoMarca ON dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId = dbo.ProductoMarca.Id INNER JOIN
                         dbo.Empresa AS LicitanteEmpresa ON dbo.LicitanteProductoMarca.LicitanteId = LicitanteEmpresa.Id INNER JOIN
                         dbo.LicitacionPartida ON dbo.LicitacionPartidaProducto.LicitacionPartidaId = dbo.LicitacionPartida.Id INNER JOIN
                         dbo.Licitacion ON dbo.LicitacionPartida.LicitacionId = dbo.Licitacion.Id INNER JOIN
                         dbo.Licitador ON dbo.Licitacion.LicitadorId = dbo.Licitador.Id INNER JOIN
                         dbo.Empresa AS LicitadorEmpresa ON dbo.Licitador.Id = LicitadorEmpresa.Id
GROUP BY    dbo.LicitanteProductoMarca.LicitanteId, LicitanteEmpresa.Nombre, dbo.Licitacion.LicitadorId, LicitadorEmpresa.Nombre, dbo.LicitacionPartida.LicitacionId, 
                         dbo.LicitacionPartidaProducto.LicitacionPartidaId, dbo.LicitacionPartidaProducto.Id, dbo.LicitacionPartidaProducto.ProductoId, dbo.Producto.Nombre, 
                         dbo.LicitacionPartidaProducto.Cantidad, dbo.LicitacionPartidaProducto.Observaciones, dbo.LicitacionPartidaProductoMarcas.ProductoMarcaId, 
                         dbo.ProductoMarca.Nombre
