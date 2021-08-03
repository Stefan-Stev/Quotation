import { Status } from "./status.model";

export interface Quotation {
    id: string;
    name: string;
    dossierId: string;
    price: number;
    stauts: Status;
    creationDate: Date;
    validUntilDate: Date;



}