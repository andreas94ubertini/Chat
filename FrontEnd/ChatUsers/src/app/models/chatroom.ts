import { Message } from './message';
import { Utenti } from './utenti';

export class Chatroom {
  idc: string | undefined;
  roN: string | undefined;
  des: string | undefined;
  use: Utenti[] | undefined;
  messages: Message[] | undefined;
}
