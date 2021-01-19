GO
CREATE OR ALTER PROCEDURE SemestreExcel (@TablaE SemestreExcel READONLY) AS
	BEGIN
		BEGIN TRANSACTION
			BEGIN TRY
				-- se declara la tabla temporal
				DECLARE @Tabla AS TABLE (
						Id INT  NOT NULL,
						Anio INT,
						Periodo CHAR(1),
						CodigoCurso VARCHAR(15),
						NumeroGrupo INT,
						CarnetEstudiante VARCHAR(15),
						Profesor1 VARCHAR(15)
						);
	
				-- se hace una copia temporal de la tabla recibida para poder recorrerla
				INSERT INTO @Tabla SELECT Id, Anio, Periodo, CodigoCurso, NumeroGrupo, CarnetEstudiante, Profesor1
					FROM @TablaE;
	
				DECLARE @Count INT = (SELECT COUNT(*) from @Tabla);

				WHILE @Count > 0
				BEGIN
					DECLARE @Id INT = (SELECT TOP(1) Id from @Tabla order by Id),
							@Anio INT = (SELECT TOP(1) Anio from @Tabla order by Id),
							@Periodo VARCHAR(1) = (SELECT TOP(1) Periodo from @Tabla order by Id),
							@CodigoCurso VARCHAR(15) = (SELECT TOP(1) CodigoCurso from @Tabla order by Id),
							@NumeroGrupo INT = (SELECT TOP(1) NumeroGrupo from @Tabla order by Id),
							@CarnetEstudiante VARCHAR(15) = (SELECT TOP(1) CarnetEstudiante from @Tabla order by Id),
							@Profesor1 VARCHAR(15) = (SELECT TOP(1) Profesor1 from @Tabla order by Id),
				
							@Grupo_identifier VARCHAR(15),
							-- contadores
							@ContadorSemestre INT,
							@ContadorGrupo INT,
							@ContadorEstudianteGrupo INT,
							@ContadorProfesorCurso INT;
		
					SET @Grupo_identifier = @CodigoCurso + '_' + CONVERT(VARCHAR, @NumeroGrupo);

					SET @ContadorGrupo = (SELECT COUNT(*) FROM GRUPO WHERE @Grupo_identifier = grupo_id);

					SET @ContadorProfesorCurso = (SELECT COUNT(*) FROM PROFESOR_CURSO WHERE profesor_id = @Profesor1 AND curso_id = @CodigoCurso);

					SET @ContadorEstudianteGrupo = (SELECT COUNT(*) FROM ESTUDIANTE_GRUPO WHERE @CarnetEstudiante = estudiante_id AND @Grupo_identifier = grupo_id);

					IF NOT EXISTS(SELECT * FROM CURSO WHERE codigo = @CodigoCurso)
						BEGIN
							INSERT INTO CURSO(codigo, creditos, carrera, nombre) VALUES 
								(@CodigoCurso, 3, 'N/A', 'TEST');
						END

					-- se revisa que el profesor no exista
					IF(@ContadorProfesorCurso = 0)
						BEGIN
						IF NOT EXISTS (SELECT * FROM PROFESOR WHERE cedula = @Profesor1)
							BEGIN
								INSERT INTO PROFESOR(cedula) VALUES(@Profesor1);
							END
						INSERT INTO PROFESOR_CURSO(profesor_id, curso_id) VALUES 
								(@Profesor1, @CodigoCurso);
						END

					-- se verifica que el grupo no exista
					IF(@ContadorGrupo = 0)
						BEGIN
							INSERT INTO GRUPO(grupo_id, numero_grupo, cupo, anio, periodo, curso_id, profesor_id) VALUES
									(@Grupo_identifier, @NumeroGrupo, 30, @Anio, @Periodo, @CodigoCurso, @Profesor1);
						END
				   
					-- se revisa que el estudiante no exista en ese grupo
					IF(@ContadorEstudianteGrupo = 0)
						BEGIN
							-- se insertan los estudiantes en su grupo respectivo
							IF NOT EXISTS (SELECT * FROM ESTUDIANTE WHERE carnet = @CarnetEstudiante)
								BEGIN
									INSERT INTO ESTUDIANTE(carnet) VALUES (@CarnetEstudiante);
								END
							INSERT INTO ESTUDIANTE_GRUPO(estudiante_id, grupo_id) VALUES
									(@CarnetEstudiante, @Grupo_identifier);
							INSERT INTO ESTUDIANTE_CURSO(estudiante_id, curso_id) VALUES
									(@CarnetEstudiante, @CodigoCurso);

						END

					DELETE @Tabla where Id = @Id;
					SET @Count = (SELECT COUNT(*) from @Tabla);
				END
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
			END CATCH;
	END
GO
/*
DECLARE @TablaE SemestreExcel;
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(1, '2019A0021','CE3101',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(2, '2019A0026','CE3104',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(3, '2019A0026','CE3104',2021,'1',1,'3-3333-3333');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(4, '2019A0031','CE4101',2021,'1',2,'2-2222-2222');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(5, '2019A0036','CE3101',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(6, '2019A0041','CE3104',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(7, '2019A0041','CE3104',2021,'1',1,'3-3333-3333');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(8, '2019A0046','CE4101',2021,'1',2,'2-2222-2222');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(9, '2019A0221','CE3101',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(10, '2019B0022','CE3101',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(11, '2019B0027','CE3104',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(12, '2019B0027','CE3104',2021,'1',1,'3-3333-3333');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(13, '2019B0032','CE4101',2021,'1',2,'2-2222-2222');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(14, '2019B0037','CE3101',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(15, '2019B0042','CE3104',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(16, '2019B0042','CE3104',2021,'1',1,'3-3333-3333');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(17, '2019B0047','CE4101',2021,'1',2,'2-2222-2222');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(18, '2019C0023','CE3101',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(19, '2019C0028','CE3104',2021,'1',1,'1-1111-1111');
INSERT INTO @TablaE(Id, CarnetEstudiante, CodigoCurso, Anio, Periodo, NumeroGrupo, Profesor1) 
					VALUES(20, '2019C0028','CE3104',2021,'1',1,'3-3333-3333');
EXEC SemestreExcel @TablaE;
SELECT * FROM @TablaE;

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

--DROP PROCEDURE SemestreExcel
--DROP PROCEDURE spSemestreExcel
*/
