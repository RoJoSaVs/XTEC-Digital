/*
select * from ARCHIVO;
select * from CARPETA;
select * from CURSO;
select * from ENTREGABLE;
select * from ESTUDIANTE;
select * from ESTUDIANTE_CURSO;
select * from ESTUDIANTE_GRUPO;
select * from EVALUACION;
select * from GRUPO;
select * from NOTICIA;
select * from PROFESOR;
select * from PROFESOR_CURSO;
select * from RUBROS;
select * from SUB_GRUPO;
*/



---------------------------------------------------------------------------
-----------------INSERTA LOS DATOS DE LOS CURSOS---------------------------
---------------------------------------------------------------------------
INSERT INTO CURSO(codigo, creditos, carrera, nombre) VALUES
	('MA0101', 4, 'Matematica', 'Matematica General'),
	('MA0102', 4, 'Matematica', 'Calculo Diferencial e Integral'),
	('MA0103', 4, 'Matematica', 'Calculo y Algebra Lineal'),
	('MA2105', 4, 'Matematica', 'Ecuaciones diferenciales'),
	('MA2104', 4, 'Matematica', 'Calculo superior'),
	('CE3101', 4, 'Ing. Computadores', 'Bases de Datos'),
	('CE3104', 4, 'Ing. Computadores', 'Lenguajes, Compiladores e interpretes'),
	('CE4101', 4, 'Ing. Computadores', 'Especificacion y Diseno de Software'),
	('CE2021', 4, 'Ing. Computadores', 'Algoritmos y estructuras de datos 1'),
	('FI3454', 3, 'Fisica', 'Fisica de Plasmas');



---------------------------------------------------------------------------
-----------------INSERTA LOS DATOS DE ESTUDIANTE---------------------------
---------------------------------------------------------------------------
INSERT INTO ESTUDIANTE(carnet) VALUES
	('2018114634'),
	('2018109283'),
	('2020109283'),
	('2012178906');


---------------------------------------------------------------------------
---------------INSERTA LOS DATOS DE LOS PROFESORES-------------------------
---------------------------------------------------------------------------
INSERT INTO PROFESOR(cedula) VALUES
    ('562856435684567'),
    ('262656436684367'),
    ('304656873684367'),
    ('334677773684317');




---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE GRUPO-----------------------------------
---------------------------------------------------------------------------
INSERT INTO GRUPO(grupo_id, numero_grupo, cupo, anio, periodo, curso_id, profesor_id) VALUES
	('CE3101_1', 1, 24, 2020, '1', 'CE3101', '562856435684567'),
	('CE3101_2', 2, 24, 2020, '2', 'CE3101', '262656436684367'),
	('CE3104_1', 1, 24, 2020, '2', 'CE3104', '562856435684567'),
	('MA0103_1', 1, 30, 2020, 'V', 'MA0103', '304656873684367'),
	('MA0103_2', 2, 30, 2020, 'V', 'MA0103', '334677773684317'),
	('MA2104_1', 1, 30, 2020, '1', 'MA2104', '262656436684367'),
	('MA2104_2', 2, 30, 2020, '2', 'MA2104', '304656873684367'),
	('MA2105_1', 1, 30, 2020, '1', 'MA2105', '334677773684317'),
	('MA2105_2', 2, 30, 2020, '2', 'MA2105', '304656873684367'),
	('CE2021_1', 1, 24, 2018,'2','CE2021','562856435684567'),
	('FI3454_3', 3, 40, 2020,'1','FI3454','334677773684317');


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS CARPETAS----------------------------
---------------------------------------------------------------------------
INSERT INTO CARPETA(carpeta_id, nombre, ruta_url, grupo_id) VALUES
	('CE3101_1PT','PRESENTACIONES', '/ingreso/presentaciones', 'CE3101_1'),
	('CE3101_1Q','QUICES', '/ingreso/quices', 'CE3101_1'),
	('CE3101_1E','EXAMENES', '/ingreso/examenes', 'CE3101_1'),
	('CE3101_1PY','PROYECTOS', '/ingreso/proyectos', 'CE3101_1'),
	------------------------------------------------------------
	('CE3101_2PT','PRESENTACIONES', '/ingreso/presentaciones', 'CE3101_2'),
	('CE3101_2Q','QUICES', '/ingreso/quices', 'CE3101_2'),
	('CE3101_2E','EXAMENES', '/ingreso/examenes', 'CE3101_2'),
	('CE3101_2PY','PROYECTOS', '/ingreso/proyectos', 'CE3101_2'),
	------------------------------------------------------------
	('MA0103_1PT','PRESENTACIONES', '/ingreso/presentaciones', 'MA0103_1'),
	('MA0103_1Q','QUICES', '/ingreso/quices', 'MA0103_1'),
	('MA0103_1E','EXAMENES', '/ingreso/examenes', 'MA0103_1'),
	('MA0103_1PY','PROYECTOS', '/ingreso/proyectos', 'MA0103_1'),
	------------------------------------------------------------
	('MA2104_1PT','PRESENTACIONES', '/ingreso/presentaciones', 'MA2104_1'),
	('MA2104_1Q','QUICES', '/ingreso/quices', 'MA2104_1'),
	('MA2104_1E','EXAMENES', '/ingreso/examenes', 'MA2104_1'),
	('MA2104_1PY','PROYECTOS', '/ingreso/proyectos', 'MA2104_1'),
	------------------------------------------------------------
	('FI3454_3PT','PRESENTACIONES', '/ingreso/presentaciones', 'FI3454_3'),
	('FI3454_3Q','QUICES', '/ingreso/quices', 'FI3454_3'),
	('FI3454_3E','EXAMENES', '/ingreso/examenes', 'FI3454_3'),
	('FI3454_3PY','PROYECTOS', '/ingreso/proyectos', 'FI3454_3');



---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS NOTICIAS----------------------------
---------------------------------------------------------------------------
/*INSERT INTO NOTICIA(noticia_id, titulo, mensaje, fecha, autor, grupo_id) VALUES
	('FI3454_3_N1','Examen evaluado', 'en su examen obtuvo una nota de 98', '2021-01-17', 'Allan Calderon', 'FI3454_3'),
	('MA2104_1_N1','Fecha de examen', 'Su examen sera el dia jueves 12 de diciembre a las 3 pm, con duracion de 3 horas', '2020-12-04', 'Fabian Fallas','MA2104_1'),
	('CE3101_1_N1','Temas de examen', 'Los temas del examen son del capitulo 1 al 3', '2020-12-10', 'Mario Chacon', 'CE3101_1');
*/


---------------------------------------------------------------------------
---------------INSERTA LOS DATOS DE LAS ARCHIVO----------------------------
---------------------------------------------------------------------------
/*INSERT INTO ARCHIVO(archivo_id, nombre, archivo_pdf, tamanio, fecha, carpeta_id) VALUES
	('CE3101_1E_A1','Examen Bases de Datos', 'examen.pdf', 20,'2020-12-04','CE3101_1E'),
	('CE3101_1Q_A1','Archivo Adjunto Bases de Datos', 'archivo1.pdf', 20,'2020-12-04','CE3101_1Q'),
	('MA2104_1P_A1','correos', 'correosDeConsulta.pdf', 20,'2020-12-04','MA2104_1PT');
*/

--------------------------------------------------------------------------
----------------INSERTA LOS DATOS DE LOS RUBROS---------------------------
--------------------------------------------------------------------------
INSERT INTO RUBROS(rubro_id, nombre, porcentaje, grupo_id) VALUES
    ('CE3101_1Q', 'Quices', 30, 'CE3101_1'),
    ('CE3101_1E', 'Examenes', 30, 'CE3101_1'),
    ('CE3101_1P', 'Proyectos', 40, 'CE3101_1'),
	-------------------------------------------
	('CE3104_1Q', 'Quices', 30, 'CE3104_1'),
    ('CE3104_1E', 'Examenes', 30, 'CE3104_1'),
    ('CE3104_1P', 'Proyectos', 40, 'CE3104_1'),
	-------------------------------------------
	('MA0103_1Q', 'Quices', 30, 'MA0103_1'),
    ('MA0103_1E', 'Examenes', 30, 'MA0103_1'),
    ('MA0103_1P', 'Proyectos', 40, 'MA0103_1'),
	-------------------------------------------
	('FI3454_3Q', 'Quices', 30, 'FI3454_3'),
    ('FI3454_3E', 'Examenes', 30, 'FI3454_3'),
    ('FI3454_3P', 'Proyectos', 40, 'FI3454_3');



---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS EVALUACIONES------------------------
---------------------------------------------------------------------------
/*INSERT INTO EVALUACION(evaluacion_id, nombre, fecha_entrega, grupal_individual, porcentaje, rubro_id) VALUES
    ('CE3101_1P_E1', 'STRAVIATEC', '2021-02-14', 1, 25, 'CE3101_1P'),
	----------------------------------------------------------------
    ('FI3454_3E_E1', 'Torque', '2021-01-17' , 0, 15, 'FI3454_3E'),
    ----------------------------------------------------------------
	('MA0103_1P_E1', 'Racionalizacion', '2020-12-25', 0, 15, 'MA0103_1P');
*/


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LOS ENTREGABLES-------------------------
---------------------------------------------------------------------------
/*INSERT INTO ENTREGABLE(entregable_id, nota, observaciones, publico, evaluado, evaluacion_id) VALUES
    ('CE3101_1P_E1', 100, 'Buen trabajo', 0, 0, 'CE3101_1P_E1'),
    ('CE3101_1P_E2', 90, 'Desarrollar las conclusiones', 0, 0, 'CE3101_1P_E1'),
	----------------------------------------------------------------------------
    ('FI3454_3E_E1', 80, 'Presenta errores algebraicos', 0, 0, 'FI3454_3E_E1'),
    ('FI3454_3E_E2', 100, 'Excelente, se mostrará como ejemplo', 1, 0, 'FI3454_3E_E1');
*/


---------------------------------------------------------------------------
-----------------INSERTA LOS DATOS DE SUB GRUPOS---------------------------
---------------------------------------------------------------------------
INSERT INTO SUB_GRUPO(sub_grupo_id, estudiante_id, grupo_id, entregable_id) VALUES
    ('CE3101_1_S1','2018114634','CE3101_1','CE3101_1P_E1'),
    ('CE3101_1_S1','2018109283','CE3101_1','CE3101_1P_E1'),
	('CE3101_1_S1','2020109283','CE3101_1','CE3101_1P_E1'),
	------------------------------------------------------
    ('FI3454_3_S1','2012178906','FI3454_3','FI3454_3E_E1'),
    ('FI3454_3_S1','2018109283','FI3454_3','FI3454_3E_E1');
	


---------------------------------------------------------------------------
--------------INSERTA LAS RELACIONES PROFESOR-CURSO------------------------
---------------------------------------------------------------------------
INSERT INTO PROFESOR_CURSO(profesor_id, curso_id) VALUES 
    ('562856435684567', 'MA0101'),
    ('334677773684317', 'FI3454'),
    ('304656873684367', 'CE3101');



---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE ESTUDIANTE-CURSO------------------------
---------------------------------------------------------------------------
INSERT INTO ESTUDIANTE_CURSO(estudiante_id, curso_id) VALUES
	('2018114634', 'CE3101'),
	('2020109283', 'CE3101'),
	('2012178906', 'CE3101');




---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE ESTUDIANTE-GRUPO------------------------
---------------------------------------------------------------------------
INSERT INTO ESTUDIANTE_GRUPO(estudiante_id, grupo_id) VALUES
	('2018114634', 'CE3101_1'),
	('2020109283', 'CE3101_1'),
	('2012178906', 'CE3101_1');