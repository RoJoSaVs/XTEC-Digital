/** SCRIPT DE CREACION DE TABLAS**/
--CREATE DATABASE XTEC_DIGITAL;

--CREACION DE LAS TABLAS

CREATE TABLE CURSO(
	codigo VARCHAR(15),
	nombre VARCHAR(30) NOT NULL,
	creditos INT NOT NULL,
	carrera VARCHAR(30) NOT NULL,

	PRIMARY KEY(codigo)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE ESTUDIANTE(
	carnet VARCHAR(15),
	PRIMARY KEY(carnet)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE PROFESOR(
	cedula VARCHAR(15),
	PRIMARY KEY (cedula)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE GRUPO(
	grupo_id VARCHAR(15),
	matriculados INT,
	numero_grupo INT,
	cupo INT,
	anio INT,
	periodo CHAR(1),

	curso_id VARCHAR(15),--FK
	profesor_id VARCHAR(15),--FK

	PRIMARY KEY(grupo_id)--, numero_grupo, anio, periodo)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE CARPETA(
	carpeta_id VARCHAR(15),
	nombre VARCHAR(15),
	ruta_url VARCHAR,

	grupo_id VARCHAR(15),--FK

	PRIMARY KEY(carpeta_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE NOTICIA(
	noticia_id VARCHAR(15),
	titulo VARCHAR(30),
	mensaje VARCHAR,
	fecha DATE,

	grupo_id VARCHAR(15), --FK

	PRIMARY KEY(noticia_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE ARCHIVO(
	archivo_id VARCHAR(15),
	nombre VARCHAR(30),
	archivo_pdf VARCHAR,
	tamanio INT,
	fecha DATE,

	carpeta_id VARCHAR(15), --FK

	PRIMARY KEY(archivo_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE RUBROS(
	rubro_id VARCHAR(15),
	nombre VARCHAR(30),
	porcentaje INT,

	grupo_id VARCHAR(15), --FK

	PRIMARY KEY(rubro_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE EVALUACION(
	evaluacion_id VARCHAR(15),
	nombre VARCHAR(30),
	fecha_entrega DATE,
	grupal_individual BIT,
	especificacion_archivo VARCHAR,
	porcentaje INT,

	rubro_id VARCHAR(15), --FK

	PRIMARY KEY(evaluacion_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE ENTREGABLE(
	entregable_id VARCHAR(15),
	nota INT,
	observaciones VARCHAR,
	archivo_retroalimentacion VARCHAR,
	archivo_entregable VARCHAR,
	publico BIT,
	evaluado BIT,

	evaluacion_id VARCHAR(15), --FK

	PRIMARY KEY(entregable_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE SUB_GRUPO(
	sub_grupo_id VARCHAR(15), --FK
	estudiante_id VARCHAR(15), --FK
	grupo_id VARCHAR(15), --FK
	entregable_id VARCHAR(15), --FK

	PRIMARY KEY(sub_grupo_id, estudiante_id, grupo_id, entregable_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE PROFESOR_CURSO(
	profesor_id VARCHAR(15), --FK
	curso_id VARCHAR(15), --FK

	PRIMARY KEY(profesor_id, curso_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE ESTUDIANTE_CURSO(
	estudiante_id VARCHAR(15), --FK
	curso_id VARCHAR(15), --FK

	PRIMARY KEY(estudiante_id, curso_id)
);
------------------------------------------------------------
------------------------------------------------------------
CREATE TABLE ESTUDIANTE_GRUPO(
	estudiante_id VARCHAR(15), --FK
	grupo_id VARCHAR(15), --FK

	PRIMARY KEY(estudiante_id, grupo_id)
);