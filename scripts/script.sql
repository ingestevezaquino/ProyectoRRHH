CREATE TABLE Roles(
	Id SERIAL,
	Descripcion VARCHAR(50),
	CONSTRAINT pk_rol_id PRIMARY KEY (Id)
);


CREATE TABLE Usuarios(
	Id SERIAL,
	Nombre VARCHAR(50),
	Correo VARCHAR(50),
	Clave VARCHAR(50),
	IdRol INT,
	CONSTRAINT pk_usuarios_id PRIMARY KEY (Id),
	CONSTRAINT fk_usuarios_idrol FOREIGN KEY (IdRol) REFERENCES Rol(Id)
);


CREATE TABLE Competencias(
	Id SERIAL,
	Descripcion VARCHAR(100),
	Estado BOOLEAN,
	CONSTRAINT pk_competencia_id PRIMARY KEY (Id),
	CONSTRAINT uq_competencias_descripcionCompetencia UNIQUE (Descripcion)
);

CREATE TABLE Idiomas(
	Id SERIAL,
	Nombre VARCHAR(20),
	Nivel VARCHAR(20),
	CONSTRAINT pk_idiomas_id PRIMARY KEY (Id),
	CONSTRAINT uq_idiomas_nombre UNIQUE (Nombre)
);

CREATE TABLE Capacitaciones(
	Id SERIAL,
	Descripcion VARCHAR(100),
	Nivel VARCHAR(20),
	FechaDesde DATE,
	FechaHasta DATE,
	Institucion VARCHAR(50),
	CONSTRAINT pk_capacitacion_id PRIMARY KEY (Id),
	CONSTRAINT uq_capacitaciones_descripcionCapacitacion UNIQUE (Descripcion)
);

CREATE TABLE Puestos(
	Id SERIAL,
	Nombre VARCHAR(50),
	NivelRiesgo VARCHAR(10),
	SalarioMin VARCHAR(20),
	SalarioMax VARCHAR(20),
	Estado BOOLEAN,
	CONSTRAINT pk_puesto_id PRIMARY KEY (Id),
	CONSTRAINT uq_puestos_nombre UNIQUE (Nombre)
);

CREATE TABLE Departamentos(
	Id SERIAL,
	Departamento VARCHAR(50),
	CONSTRAINT pk_departamento_id PRIMARY KEY (Id),
	CONSTRAINT uq_departamentos_departamento UNIQUE (Departamento)
);

CREATE TABLE ExpLaboral(
	Id SERIAL,
	Empresa VARCHAR(100),
	PuestoOcupado VARCHAR(100),
	FechaDesde DATE,
	FechaHasta DATE,
	Salario VARCHAR(20),
	CONSTRAINT pk_expLaboral_id PRIMARY KEY (Id),
	CONSTRAINT uq_explaboral_empresa UNIQUE (Empresa)
);

CREATE TABLE Candidatos(
	Id SERIAL,
	Cedula VARCHAR(30),
	Nombre VARCHAR(60),
	PuestoAspira VARCHAR(50),
	Departamento VARCHAR(30),
	SalarioAspira VARCHAR(10),
	Capacitaciones VARCHAR(60),
	ExpLaboral VARCHAR(50),
	RecomendadoPor VARCHAR(60),
	CONSTRAINT pk_candidatos_id PRIMARY KEY (Id),
	CONSTRAINT uq_candidatos_cedula UNIQUE (Cedula),
	CONSTRAINT fk_candidatos_puestoAspira FOREIGN KEY (PuestoAspira) REFERENCES Puestos(Nombre),
	CONSTRAINT fk_candidatos_departamento FOREIGN KEY (Departamento) REFERENCES Departamentos(Departamento),
	CONSTRAINT fk_candidatos_capacitaciones FOREIGN KEY (Capacitaciones) REFERENCES Capacitaciones(Descripcion),
	CONSTRAINT fk_candidatos_expLaboral FOREIGN KEY (ExpLaboral) REFERENCES ExpLaboral(Empresa)
);

CREATE TABLE CandidatosCompetencias (
	CandidatoId INT,
	CompetenciaId INT,
	CONSTRAINT pk_candidatos_competencias PRIMARY KEY (CandidatoId, CompetenciaId),
	CONSTRAINT fk_candidatos_competencias_candidatoId FOREIGN KEY (CandidatoId) REFERENCES Candidatos(Id),
	CONSTRAINT fk_candidatos_competencias_competenciaId FOREIGN KEY (CompetenciaId) REFERENCES Competencias(Id)
);

CREATE TABLE Empleados(
	Id SERIAL,
	Cedula VARCHAR(30),
	Nombre VARCHAR(50),
	FechaIngreso DATE,
	Departamento VARCHAR(50),
	Puesto VARCHAR(50),
	SalarioMensual VARCHAR(10),
	Estado BOOLEAN,
	CONSTRAINT pk_empleados_id PRIMARY KEY (Id),
	CONSTRAINT fk_empleados_cedula FOREIGN KEY (Cedula) REFERENCES Candidatos(Cedula),
	CONSTRAINT uq_empleados_cedula UNIQUE (Cedula),
	CONSTRAINT fk_empleados_departamento FOREIGN KEY (Departamento) REFERENCES Departamentos(Departamento),
	CONSTRAINT fk_empleados_puesto FOREIGN KEY (Puesto) REFERENCES Puestos(Nombre)
);


INSERT INTO Roles(Id, Descripcion) VALUES 
(1, 'Administrador'), 
(2, 'Candidato');

INSERT INTO Usuarios(id,nombre,correo,clave,idRol) VALUES 
(1, 'Rocio', 'ro@gmail.com', '123', 1), 
(2, 'Albert', 'ab@gmail.com', '456', 2);
