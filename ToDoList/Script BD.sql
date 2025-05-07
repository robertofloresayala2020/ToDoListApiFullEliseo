/*CREATE TABLE Tareas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255),
    FechaLimite DATETIME NOT NULL,
    FechaCreacion DATETIME DEFAULT GETUTCDATE()
);

CREATE TABLE EstatusTareas (
    IdEstatus INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255),
);


ALTER TABLE Tareas
	ADD   IdEstatus INT  NULL

GO
ALTER TABLE Tareas
ADD CONSTRAINT [FK_IdEstatus]
FOREIGN KEY ([IdEstatus])
REFERENCES EstatusTareas([IdEstatus])
ON DELETE SET NULL;


insert into EstatusTareas 
values ('Activo'),('Completado'),('Cancelado')


*/

CREATE TABLE Tareas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255),
	Estatus NVARCHAR(255),
    FechaLimite DATETIME NOT NULL,
    FechaCreacion DATETIME DEFAULT GETUTCDATE()
);

truncate table Tareas
