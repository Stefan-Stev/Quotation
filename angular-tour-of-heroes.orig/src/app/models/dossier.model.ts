import { Quotation } from "./quotation.model";

export interface Dossier {
    id: string;
    name: string;
    year: number;
    quotations: Quotation[];
}