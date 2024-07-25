CREATE DATABASE CHUBB

USE CHUBB

CREATE TABLE Empleados(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Fotografia VARCHAR(MAX),
	Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL,
	PuestoId INT NOT NULL,
	FechaNacimiento DATETIME NOT NULL,
	Direccion VARCHAR(200) NOT NULL,
	Telefono VARCHAR(50) NOT NULL,
	CorreoElectronico VARCHAR(100) NOT NULL,
	EstadoId INT NOT NULL
)

CREATE TABLE Puestos(
	Id INT NOT NULL PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL 
)

--AL SER CATALOGO INSERTO DATOS DE INICIO
INSERT INTO Puestos VALUES(1, 'Jefe')
INSERT INTO Puestos VALUES(2, 'Empleado')

CREATE TABLE Estados(
	Id INT NOT NULL PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL 
)

--AL SER CATALOGO INSERTO DATOS DE INICIO
INSERT INTO Estados VALUES(1, 'Activo')
INSERT INTO Estados VALUES(2, 'Inactivo')

CREATE PROCEDURE spAdminEmpleados
	@Opcion INT,
	@Id INT = 0,
	@Fotografia VARCHAR(MAX) = '',
	@Nombre VARCHAR(50) = '',
	@Apellido VARCHAR(50) = '',
	@PuestoId INT = 0,
	@FechaNacimiento DATETIME = '01/01/1900',
	@Direccion VARCHAR(200) = '',
	@Telefono VARCHAR(50) = '',
	@CorreoElectronico VARCHAR(100) = '',
	@EstadoId INT = 0
AS 
BEGIN
	IF @Opcion = 1 --INSERT
	BEGIN
		INSERT INTO Empleados VALUES(@Fotografia, @Nombre, @Apellido, @PuestoId, @FechaNacimiento, @Direccion, @Telefono, @CorreoElectronico, @EstadoId)
	END

	IF @Opcion = 2 --DELETE
	BEGIN
		DELETE FROM Empleados WHERE Id = @Id
	END

	IF @Opcion = 3 --UPDATE
	BEGIN
		UPDATE Empleados 
			SET Fotografia= @Fotografia, 
			Nombre = @Nombre, 
			Apellido = @Apellido, 
			PuestoId = @PuestoId, 
			FechaNacimiento = @FechaNacimiento, 
			Direccion = @Direccion, 
			Telefono = @Telefono, 
			CorreoElectronico = @CorreoElectronico, 
			EstadoId = @EstadoId
		WHERE Id = @Id
	END

	IF @Opcion = 4 --SELECT
	BEGIN
		IF @Id <> 0
			SELECT * FROM Empleados WHERE Id = @Id
		ELSE
			SELECT * FROM Empleados
	END
END
