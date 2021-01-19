--##########################################################################################################--
/*
Reporte de Estudiantes Matriculados: Mostrar la lista de estudiantes matriculados en el curso, indicando carnet, 
nombre, correo electrónico y teléfono. Este reporte debe presentarse utilizando una Vista en la base de datos
y usando herramientas como Reporting Services o Cristal Reports. Debe permitir descagar la información en un PDF.
*/
GO 
CREATE VIEW MatriculadosV AS
	SELECT EC.estudiante_id, C.codigo, C.nombre FROM (ESTUDIANTE_CURSO AS EC INNER JOIN CURSO C ON EC.curso_id = C.codigo);
GO
/*
SELECT * FROM MatriculadosV;
SELECT * FROM ESTUDIANTE_CURSO;
SELECT * FROM CURSO;
DROP VIEW MatriculadosV;
*/
--##########################################################################################################--