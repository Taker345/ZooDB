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

--POST AGREGAR NUEVO 

CREATE PROCEDURE AgregarEspecie
	@idClasificacion INT 
	,@idTipoAnimal BIGINT
	,@nombre NVARCHAR (50)
	,@nPatas SMALLINT
	,@esMascota BIT
AS
BEGIN
	INSERT INTO Especies 
	(idClasificacion, idTipoAnimal, nombre, nPatas, esMascota)
	 VALUES 
	 (@idClasificacion, @idTipoAnimal, @nombre, @nPatas, @esMascota)

END

--PUT ACTUALIZAR 

CREATE PROCEDURE ActualizarEspecie
    @idEspecie BIGINT
	,@idClasificacion INT 
	,@idTipoAnimal BIGINT
	,@nombre NVARCHAR (50)
	,@nPatas SMALLINT
	,@esMascota BIT
AS
BEGIN
    UPDATE Especies SET
        idClasificacion = @idClasificacion
		,idTipoAnimal = @idTipoAnimal
		,nombre = @nombre
		,nPatas = @nPatas
		,esMascota = @esMascota
    WHERE idEspecie = @idEspecie
END 

-- DELETE ELIMINAR 


CREATE PROCEDURE EliminarEspecie
    @idEspecie bigint
AS
BEGIN
    DELETE FROM Especies WHERE idEspecie = @idEspecie
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

--PUT ACTUALIZAR 
CREATE PROCEDURE ActualizarTipoAnimal

	@idTipoAnimal BIGINT 
	,@denominacion NVARCHAR(50)
AS
BEGIN
    UPDATE TipoAnimal SET

        denominacion = @denominacion

    WHERE idTipoAnimal = @idTipoAnimal
END 

-- DELETE ELIMINAR 


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

--PUT ACTUALIZAR 

CREATE PROCEDURE ActualizarClasificacion

	@idClasificacion INT 
	,@denominacion NVARCHAR(50)
AS
BEGIN
    UPDATE Clasificacion SET

        denominacion = @denominacion

    WHERE idClasificacion = @idClasificacion
END 

-- DELETE ELIMINAR 

CREATE PROCEDURE EliminarClasificacion
    @idClasificacion bigint
AS
BEGIN
    DELETE FROM Clasificacion WHERE idClasificacion = @idClasificacion
END