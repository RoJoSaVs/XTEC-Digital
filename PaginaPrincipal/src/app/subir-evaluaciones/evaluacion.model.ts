//define el modelo del JSON que se enviará al server desde este componente
export class EvaluacionModel {
    rubro :string;
    fecha_de_entrega: Date;
    peso: number;
    idGrupo : String;
    grupal: boolean;
    especificacion: File;
} 
