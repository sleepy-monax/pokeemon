import {Stat} from './stat';
import {Action} from './action';

export interface Stereotype {
  name: string;
  stats: Stat;
  action: Action[];
}
