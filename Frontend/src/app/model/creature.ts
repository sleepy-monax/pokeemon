import {Stat} from './stat';
import {Action} from './action';

export interface Creature {
  id?: number;
  name?: string;
  stereotype: string;
  level: number;
  stat?: Stat;
  action?: Action;
}
export declare type Creatures = Creature[];
