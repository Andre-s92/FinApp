import { OperationModel } from "./operationModel";

export interface FinancialReleaseModel {
  id: number;
  operationId: number;
  cnpj: string;
  name: string;
  phone: string;
  zipCode: string;
  address: string;
  state: string;
  city: string;
  district: string;
  releaseDate: Date;
  dueDate: Date;
  discount: number;
  amount: number;
  number: string;
  operation: OperationModel

}
