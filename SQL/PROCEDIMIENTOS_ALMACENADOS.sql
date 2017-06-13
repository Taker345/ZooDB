--PROCEDIMEINTOS ALMACENADOS PARA BASE DE DATOS ZOODB!!!




---o-o-o-o-o-o-o-o-o-o-o-o-o-ESPECIES-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-




--1.- COJER TODAS LAS COLUMNAS PARA EL GET SOLO

Alter PROCEDURE GET_ESPECIES
AS
BEGIN
    SELECT 
	idEspecie
	,CL.idClasificacion
	,CL.denominacion as Clasificacion
	,TA.idTipoAnimal
	,TA.denominacion as TipoAnimal
	,nombre
	,nPatas
	,esMascota
    FROM Especies ES
       INNER JOIN TipoAnimal TA  ON TA.idTipoanimal = ES.idTipoAnimal
	   INNER JOIN Clasificacion CL ON CL.idClasificacion = ES.idClasificacion
END

--2.1- COJER TODAS LAS COLUMNAS PARA USAR EL FILTRADO EN GET (ID)

CREATE PROCEDURE GET_ESPECIES_ID

@idEspecie BIGINT

AS
BEGIN
    SELECT 
	idEspecie
	,CL.idClasificacion
	,CL.denominacion as Clasificacion
	,TA.idTipoAnimal
	,TA.denominacion as TipoAnimal
	,nombre
	,nPatas
	,esMascota
    FROM Especies ES
       INNER JOIN TipoAnimal TA  ON TA.idTipoanimal = ES.idTipoAnimal
	   INNER JOIN Clasificacion CL ON CL.idClasificacion = ES.idClasificacion

	   WHERE ES.idEspecie = @idEspecie
END




--o-o-o-o-o-o-o-o-o-o-o-o-o-ANIMALES-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-





--1.1- COJER ID Y DENOMINACON PARA EL GET SOLO

CREATE PROCEDURE GET_ANIMALES
AS
BEGIN
    SELECT idTipoAnimal, denominacion
    FROM TipoAnimal
       
END

--2.1- COJER ID Y DENOMINACON PARA USAR EL FILTRADO EN GET (ID)

CREATE PROCEDURE GET_ANIMALES_ID

@idTipoAnimal BIGINT
AS
BEGIN
	SELECT denominacion, idTipoAnimal
	FROM TipoAnimal
	WHERE TipoAnimal.idTipoAnimal = @idTipoAnimal
END
--3.1- COJER ID Y DENOMINACION PARA USARLO EN EL POST

CREATE PROCEDURE AgregarTipoAnimal
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO TipoAnimal(denominacion) VALUES (@denominacion)
END




---o-o-o-o-o-o-o-o-o-o-o-o-o-CLASIFICACION-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-




--1.2-.COJER ID Y DENOMINACON PARA EL GET SOLO

CREATE PROCEDURE GET_CLASIFICACION
AS
BEGIN
    SELECT idClasificacion, denominacion
    FROM Clasificacion
       
END

--2.2- COJER ID Y DENOMINACON PARA USAR EL FILTRADO EN GET (ID)

CREATE PROCEDURE GET_CLASIFICACION_ID

@idClasificacion INT
AS
BEGIN
	SELECT denominacion, idClasificacion
	FROM Clasificacion
	WHERE Clasificacion.idClasificacion = @idClasificacion
END


--3.2- COJER ID Y DENOMINACION PARA USARLO EN EL POST

CREATE PROCEDURE AgregarClasificacion
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO Clasificacion(denominacion) VALUES (@denominacion)
END



