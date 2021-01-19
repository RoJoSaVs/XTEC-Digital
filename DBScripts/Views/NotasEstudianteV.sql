GO
CREATE VIEW NotasEstudianteV AS
				SELECT SUB_GRUPO.estudiante_id as 'Carnet', RUBROS.nombre 'Rubro', RUBROS.porcentaje as 'PorcentajeDelRubro', 
				ENTREGABLE.nota as 'Nota' ,EVALUACION.nombre as 'NombreDeEvaluacion' , EVALUACION.porcentaje as 'PorcentajeDeEvaluacion'
				FROM (((SUB_GRUPO INNER JOIN ENTREGABLE ON SUB_GRUPO.entregable_id = ENTREGABLE.entregable_id) 
					INNER JOIN EVALUACION ON EVALUACION.evaluacion_id = ENTREGABLE.evaluacion_id)
					INNER JOIN RUBROS ON RUBROS.rubro_id = EVALUACION.rubro_id)
					--WHERE SUB_GRUPO.grupo_id = @grupo_id;
GO