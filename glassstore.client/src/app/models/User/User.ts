import { Basket } from "./Basket";
import { Orders } from "./Orders";

export interface Glasses {
  id: string; // ObjectId
  email: string;
  orders: Orders[];
  Basket: Basket;

}
