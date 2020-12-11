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
--------------INSERTA LOS DATOS DE LAS EVALUACIONES-------------------------
---------------------------------------------------------------------------
INSERT INTO EVALUACION(evaluacion_id,nombre,fecha_entrega,grupal_individual,especificacion_archivo,porcentaje,rubro_id) VALUES
    ("1","STRAVIATEC",'2021-02-14',1,NULL,25,"1"),
    ("2","Aplicacion",'2021-01-17',0,NULL,15,"11"),
    ("3","Octaniones en teoría de cuerdas",'2020-12-25',0,NULL,15,"11");


