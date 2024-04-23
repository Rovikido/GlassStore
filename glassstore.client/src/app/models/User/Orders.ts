import { Glasses } from "../Glasses/Glasses";


export interface Orders {
  glasses: Glasses[];
  totalPrice: number;
  orderDate: Date
}
