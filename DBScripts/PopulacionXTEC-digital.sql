---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LOS PROFESORES-------------------------
---------------------------------------------------------------------------
INSERT INTO PROFESOR(cedula) VALUES
    ("562856435684567"),
    ("262656436684367"),
    ("304656873684367"),
    ("334677773684317");

---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LOS CURSOS-------------------------
---------------------------------------------------------------------------
INSERT INTO CURSO(codigo,nombre,creditos,carrera) VALUES
    ("CE2056","Economía 1",2,"CE"),
    ("FI3454","Etica",3,"FI"),
    ("MA9651","Octaniones",5,"MA");


---------------------------------------------------------------------------
--------------INSERTA LAS RELACIONES PROFESOR-CURSO-------------------------
---------------------------------------------------------------------------
INSERT PROFESOR_CURSO(profesor_id,curso_id) VALUES 
    ("562856435684567","CE2056"),
    ("334677773684317","FI3454"),
    ("304656873684367","MA9651");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE SUB GRUPOS-------------------------
---------------------------------------------------------------------------
INSERT INTO SUB_GRUPO(sub_grupo_id,estudiante_id,grupo_id,entregable_id) VALUES
    ("1","Allan Calderon","CE2056","2"),
    ("1","Ronny Santamaria","CE2056","2"),
    ("2","Edgar Gonzales","MA9651","20"),
    ("2","Fabian Fallas","MA9651","20"),
    ("20","Jon Dorito","FI3454","5");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LOS RUBROS-------------------------
--------------------------------------------------------------------------
INSERT INTO RUBROS(rubro_id,nombre,porcentaje,grupo_id) VALUES
    ("1","Examen",69,"5"),
    ("20","Progra",100,"3"),
    ("11","Investigacion",42,"2");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LOS ENTREGABLES-------------------------
---------------------------------------------------------------------------
INSERT INTO ENTREGABLE(entregable_id,nota,observaciones,archivo_retroalimentacion,archivo_entregable,publico,evaluado,evaluacion_id) VALUES
    ("65",100,"AK7",NULL,NULL,0,1,"1"),
    ("15",25,"gramática",NULL,NULL,0,1,"2"),
    ("32",0,"",NULL,NULL,0,0,"3"),
    ("47",110,"Excelente, se mostrará como ejemplo",NULL,NULL,1,1,"4");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS EVALUACIONES------------------------
---------------------------------------------------------------------------
INSERT INTO EVALUACION(evaluacion_id,nombre,fecha_entrega,grupal_individual,especificacion_archivo,porcentaje,rubro_id) VALUES
    ("1","STRAVIATEC",'2021-02-14',1,NULL,25,"1"),
    ("2","Aplicacion",'2021-01-17',0,NULL,15,"11"),
    ("3","Octaniones en teoría de cuerdas",'2020-12-25',0,NULL,15,"11");


---------------------------------------------------------------------------
----------,estudiante-curso, --
---------------------------------------------------------------------------

---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS CARPETAS----------------------------
---------------------------------------------------------------------------
INSERT INTO CARPETA(carpeta_id, nombre, ruta_url, grupo_id) VALUES
	("1","DOCUMENTOS", "/ingreso/carpetas", "11"),
	("23","EXAMENES", "/ingreso/evaluaciones/examenes", "21"),
	("47","EVALUACIONES", "/ingreso/evaluaciones", "33"),
	("4","GAAP", "/ingreso/elementos/gaap", "12");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS NOTICIAS----------------------------
---------------------------------------------------------------------------
INSERT INTO NOTICIA(noticia_id,titulo,mensaje,fecha,grupo_id) VALUES
	("2","Examen evaluado", "en su examen obtuvo una nota de 98", '2021-01-17', "4"),
	("3","Fecha de examen", "Su examen sera el dia jueves 12 de diciembre a las 3 pm, con duracion de 3 horas", '2020-12-04', "3"),
	("4","Temas de examen", "Los temas del examen son del capitulo 1 al 3", '2020-12-10', "5");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE LAS ARCHIVO----------------------------
---------------------------------------------------------------------------
INSERT INTO ARCHIVO(archivo_id,nombre,archivo_pdf,tamanio,fecha,carpeta_id) VALUES
	("2","Examen Bases de Datos", "examen.pdf", 20,'2020-12-04',"4"),
	("3","Archivo Adjunto Bases de Datos", "archivo1.pdf", 20,'2020-12-04',"47"),
	("4","correos", "correosDeConsulta.pdf", 20,'2020-12-04',"8");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE ESTUDIANTE------------------------
---------------------------------------------------------------------------
INSERT INTO ESTUDIANTE(carnet) VALUES
	("2018114634"),
	("2019109283"),
	("2020109283"),
	("2012178906");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE GRUPO-----------------------------------
---------------------------------------------------------------------------
INSERT INTO GRUPO(grupo_id,matriculados,numero_grupo,cupo,anio,periodo,curso_id,profesor_id) VALUES
	("CE2021-1",28,1,30,2018,'I Semestre',"CE2021","562856435684567"),
	("FI3454-3",40,3,40,2020,'II Semestre',"FI3454","334677773684317"),
	("MA9651-17",60,17,63,2020,'II Semestre',"MA9651","262656436684367");


---------------------------------------------------------------------------
--------------INSERTA LOS DATOS DE ESTUDIANTE-CURSO------------------------
---------------------------------------------------------------------------
INSERT INTO ESTUDIANTE_CURSO(estudiante_id, curso_id) VALUES
	("2018114634","CE2056"),
	("2019109283","FI3454"),
	("2012178906","FI3454");
