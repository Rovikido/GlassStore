import { Glasses } from "../Glasses/Glasses";


export interface Orders {
  glasses: Glasses[];
  TotalPrice: number;
  OrderDate: Date
}
