/*TIPO QUE SE UTILIZA EN LA INICIALIZACION DEL EXCEL*/
CREATE TYPE SemestreExcel AS TABLE(
	Id INT  NOT NULL,
	Anio INT,
	Periodo CHAR(1),
	CodigoCurso VARCHAR(15),
	NumeroGrupo INT,
	CarnetEstudiante VARCHAR(15),
	Profesor1 VARCHAR(15),
	PRIMARY KEY (Id)
);
--DROP TYPE SemestreExcel