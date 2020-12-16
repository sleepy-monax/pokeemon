export interface User {
  id?: number;
  administrator?: boolean;
  pseudo: string;
  email: string;
  password: string;
  money?: number;
}

export declare type Users = User[];
