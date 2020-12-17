import {Stat} from './stat';
import {Action} from './action';
import {Stereotype} from './stereotype';

export interface Creature {
  id?: number;
  name?: string;
  stereotype: Stereotype;
  level: number;
  stats?: Stat;
  action?: Action;
  alive: boolean;
  pickable: boolean;
}
export declare type Creatures = Creature[];
