--##########################################################################################################--
/*
Debe permitir visualizar un reporte de notas de todos los estudiantes que forman parte del grupo del curso. 
Para cada estudiante debe mostrar el detalle de todas las notas y calcular el valor obtenido para cada rubro, 
así como la nota final curso. Este reporte debe implementarse utilizando una Vista en la base de datos
*/
GO
CREATE VIEW NotaSubgrupoPorGrupoV AS 
	SELECT e.entregable_id, e.nota, s.sub_grupo_id, s.grupo_id, s.estudiante_id, G.curso_id, G.numero_grupo, EV.nombre
	FROM ((ENTREGABLE AS E INNER JOIN SUB_GRUPO AS S ON E.entregable_id = S.entregable_id)
	INNER JOIN GRUPO AS G ON G.grupo_id = S.grupo_id) INNER JOIN EVALUACION AS EV ON E.evaluacion_id = EV.evaluacion_id;
GO
/*
SELECT * FROM NotaSubgrupoPorGrupoV Where curso_id = 'CE3101';
SELECT * FROM ENTREGABLE;
SELECT * FROM SUB_GRUPO;
DROP VIEW NotaSubgrupoPorGrupoV;

SELECT e.entregable_id, e.nota, s.sub_grupo_id, s.grupo_id, s.estudiante_id, G.curso_id, G.numero_grupo
	FROM (ENTREGABLE AS E INNER JOIN SUB_GRUPO AS S ON E.entregable_id = S.entregable_id)
	INNER JOIN GRUPO AS G ON G.grupo_id = S.grupo_id;

SELECT *
	FROM (ENTREGABLE AS E INNER JOIN SUB_GRUPO AS S ON E.entregable_id = S.entregable_id)
	INNER JOIN GRUPO ON GRUPO.grupo_id = S.grupo_id;
*/
--##########################################################################################################--