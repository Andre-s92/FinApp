import { FinancialReleaseModel } from "./financialReleaseModel";


export enum StatusOperation {
  ENVIANDO = "Enviando",
  EM_ANALISE = "Em Análise",
  PROCESSO_ASSINATURA = "Processo de Assinatura",
  PAGO = "Pagmento Realizado"
}

export interface OperationModel {
  id: number;
  description: string | null;
  status: StatusOperation;
  financialRelease: FinancialReleaseModel[]
}
