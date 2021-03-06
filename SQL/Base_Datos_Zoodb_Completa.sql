USE [Zoodb]
GO
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificacion](
	[idClasificacion] [int] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clasificacion] PRIMARY KEY CLUSTERED 
(
	[idClasificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Especies]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [bigint] IDENTITY(1,1) NOT NULL,
	[idClasificacion] [int] NOT NULL,
	[idTipoAnimal] [bigint] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[nPatas] [smallint] NOT NULL,
	[esMascota] [bit] NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoAnimal]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAnimal](
	[idTipoAnimal] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoAnimal] PRIMARY KEY CLUSTERED 
(
	[idTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Clasificacion] ON 

INSERT [dbo].[Clasificacion] ([idClasificacion], [denominacion]) VALUES (1, N'Insecto')
INSERT [dbo].[Clasificacion] ([idClasificacion], [denominacion]) VALUES (2, N'Mamifero')
INSERT [dbo].[Clasificacion] ([idClasificacion], [denominacion]) VALUES (3, N'Herbivoro')
INSERT [dbo].[Clasificacion] ([idClasificacion], [denominacion]) VALUES (4, N'Carniboro')
INSERT [dbo].[Clasificacion] ([idClasificacion], [denominacion]) VALUES (5, N'Invertebrado')
SET IDENTITY_INSERT [dbo].[Clasificacion] OFF
SET IDENTITY_INSERT [dbo].[Especies] ON 

INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (1, 1, 2, N'Pato', 2, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (2, 2, 1, N'Rana', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (3, 3, 3, N'Cabra', 4, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (4, 4, 5, N'Aguila', 2, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (5, 5, 4, N'Delfin', 0, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (6, 2, 3, N'Tiburon', 0, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (7, 4, 1, N'Leon', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (8, 3, 2, N'Perro', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (9, 1, 5, N'Gato', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (10, 5, 4, N'Lagarto', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (11, 2, 3, N'Saltamonte', 6, 0)
SET IDENTITY_INSERT [dbo].[Especies] OFF
SET IDENTITY_INSERT [dbo].[TipoAnimal] ON 

INSERT [dbo].[TipoAnimal] ([idTipoAnimal], [denominacion]) VALUES (1, N'Aquatico')
INSERT [dbo].[TipoAnimal] ([idTipoAnimal], [denominacion]) VALUES (2, N'Terrestre')
INSERT [dbo].[TipoAnimal] ([idTipoAnimal], [denominacion]) VALUES (3, N'Volador')
INSERT [dbo].[TipoAnimal] ([idTipoAnimal], [denominacion]) VALUES (4, N'Subterraneo')
INSERT [dbo].[TipoAnimal] ([idTipoAnimal], [denominacion]) VALUES (5, N'Submarino')
SET IDENTITY_INSERT [dbo].[TipoAnimal] OFF
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_Clasificacion] FOREIGN KEY([idClasificacion])
REFERENCES [dbo].[Clasificacion] ([idClasificacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_Clasificacion]
GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_TipoAnimal] FOREIGN KEY([idTipoAnimal])
REFERENCES [dbo].[TipoAnimal] ([idTipoAnimal])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_TipoAnimal]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarClasificacion]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarClasificacion]

	@idClasificacion INT 
	,@denominacion NVARCHAR(50)
AS
BEGIN
    UPDATE Clasificacion SET

        denominacion = @denominacion

    WHERE idClasificacion = @idClasificacion
END 
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEspecie]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarEspecie]
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
GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoAnimal]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarTipoAnimal]

	@idTipoAnimal BIGINT 
	,@denominacion NVARCHAR(50)
AS
BEGIN
    UPDATE TipoAnimal SET

        denominacion = @denominacion

    WHERE idTipoAnimal = @idTipoAnimal
END 
GO
/****** Object:  StoredProcedure [dbo].[AgregarClasificacion]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarClasificacion]
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO Clasificacion(denominacion) VALUES (@denominacion)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarEspecie]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarEspecie]
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

GO
/****** Object:  StoredProcedure [dbo].[AgregarTipoAnimal]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarTipoAnimal]
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO TipoAnimal(denominacion) VALUES (@denominacion)
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarClasificacion]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarClasificacion]
    @idClasificacion bigint
AS
BEGIN
    DELETE FROM Clasificacion WHERE idClasificacion = @idClasificacion
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarEspecie]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarEspecie]
    @idEspecie bigint
AS
BEGIN
    DELETE FROM Especies WHERE idEspecie = @idEspecie
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarTipoAnimal]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarTipoAnimal]
    @idTipoAnimal bigint
AS
BEGIN
    DELETE FROM TipoAnimal WHERE idTipoAnimal = @idTipoAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ANIMALES]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ANIMALES]
AS
BEGIN
    SELECT idTipoAnimal, denominacion
    FROM TipoAnimal
       
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ANIMALES_ID]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ANIMALES_ID]

@idTipoAnimal BIGINT
AS
BEGIN
	SELECT denominacion, idTipoAnimal
	FROM TipoAnimal
	WHERE TipoAnimal.idTipoAnimal = @idTipoAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GET_CLASIFICACION]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_CLASIFICACION]
AS
BEGIN
    SELECT idClasificacion, denominacion
    FROM Clasificacion
       
END
GO
/****** Object:  StoredProcedure [dbo].[GET_CLASIFICACION_ID]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GET_CLASIFICACION_ID]

@idClasificacion INT
AS
BEGIN
	SELECT denominacion, idClasificacion
	FROM Clasificacion
	WHERE Clasificacion.idClasificacion = @idClasificacion
END

GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIE]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIE]
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
GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIES_ID]    Script Date: 15/06/2017 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIES_ID]

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
GO
