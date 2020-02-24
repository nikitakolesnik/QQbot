import { Component } from '@angular/core';
import { IPlayer } from './player';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  lobby:   IPlayer[] = [];
  team1:   IPlayer[] = [];
  team2:   IPlayer[] = [];
  history: string[]  = [];

  constructor() { }

  ngOnInit(): void {
    this.setLobbyPlayerNumbers();
    this.addToLobby({ name: 'Slam',     pos: null, pref: ['w', 'd', 'r', 'e', 'n', 'me', 'prot', 'heal', 'a', 'p', 'rt'] });
    this.addToLobby({ name: 'Yoko',     pos: null, pref: ['w', 'd', 'e', 'n', 'me'] });
    this.addToLobby({ name: 'Candyboy', pos: null, pref: ['w', 'me'] });
    this.addToLobby({ name: 'Godly',    pos: null, pref: ['a'] });
    this.addToLobby({ name: 'Santana',  pos: null, pref: ['heal'] });
    this.addToLobby({ name: 'Purif',    pos: null, pref: ['me', 'prot', 'heal'] });
    this.addToLobby({ name: 'Chrona',   pos: null, pref: ['w', 'r', 'e', 'me'] });
    this.addToLobby({ name: 'Butters',  pos: null, pref: ['w', 'd', 'e'] });
    this.addToLobby({ name: 'Ice',      pos: null, pref: ['w', 'heal'] });
    this.addToLobby({ name: 'Lisek',    pos: null, pref: ['r', 'me'] });
    this.addToLobby({ name: 'Oln',      pos: null, pref: ['heal'] });
    this.addToLobby({ name: 'Rainy',    pos: null, pref: ['prot'] });
    this.addToLobby({ name: 'Takida',   pos: null, pref: ['w'] });
    this.addToLobby({ name: 'Jo',       pos: null, pref: ['e'] });
    this.addToLobby({ name: 'Bounty',   pos: null, pref: ['w', 'p', 'me'] });
    this.addToLobby({ name: 'Cracks',   pos: null, pref: ['w'] });
    this.addToLobby({ name: 'Beware',   pos: null, pref: ['prot'] });
    this.addToLobby({ name: 'Jonas',    pos: null, pref: ['w', 'prot'] });
    this.addToLobby({ name: 'Dopos',    pos: null, pref: ['r', 'me'] });
    this.addToLobby({ name: 'Hemo',     pos: null, pref: ['w', 'd'] });
  }

  // UTILITY

  removeFromList(player: IPlayer, list: IPlayer[]) : void {
    var index = list.indexOf(player);
    list.splice(index, 1);
  }

  // PAGE FUNCTIONS

  sortLobby(): void {
    this.lobby.sort((a,b) => a.pos - b.pos);
  }

  setLobbyPlayerNumbers(): void {
    for (var i = 0; i < this.lobby.length; i++)
      this.lobby[i].pos = i + 1;
  }

  addMessage(msg: string): void {
    if (this.history.length >= 22)
      this.history.pop();
    this.history.unshift('[' + new Date().toLocaleTimeString() + '] ' + msg);
  }

  addToLobby(player: IPlayer): void {
    player.pos = this.lobby.length + 1;
    this.lobby.push(player);
    this.addMessage(player.name + ' joined.');
  }

  removeFromLobby(player: IPlayer): void {
    this.removeFromList(player, this.lobby);
    this.setLobbyPlayerNumbers();
    this.addMessage('You kicked ' + player.name + '.');
  }

  lobbyToTeam1(player: IPlayer): void {
    if (this.team1.length == 8)
      return;
    this.removeFromList(player, this.lobby);
    this.team1.push(player);
    this.addMessage('You added ' + player.name + ' to Team 1.');
  }

  lobbyToTeam2(player: IPlayer): void {
    if (this.team2.length == 8)
      return;
    this.removeFromList(player, this.lobby);
    this.team2.push(player);
    this.addMessage('You added ' + player.name + ' to Team 2.');
  }

  team1ToLobby(player: IPlayer): void {
    this.removeFromList(player, this.team1);
    this.lobby.push(player);
    this.sortLobby();
    this.addMessage('You removed ' + player.name + ' from Team 1.');
  }

  team2ToLobby(player: IPlayer): void {
    this.removeFromList(player, this.team2);
    this.lobby.push(player);
    this.sortLobby();
    this.addMessage('You removed ' + player.name + ' from Team 2.');
  }

  team1ToTeam2(player: IPlayer): void {
    if (this.team2.length == 8)
      return;
    this.removeFromList(player, this.team1);
    this.team2.push(player);
    this.addMessage('You moved ' + player.name + ' to Team 2.');
  }

  team2ToTeam1(player: IPlayer): void {
    if (this.team1.length == 8)
      return;
    this.removeFromList(player, this.team2);
    this.team1.push(player);
    this.addMessage('You moved ' + player.name + ' to Team 1.');
  }

  team1Clear(): void {
    if (this.team1.length == 0)
      return;
    this.lobby = this.lobby.concat(this.team1);
    this.sortLobby();
    this.team1 = [];
    this.addMessage('You cleared Team 1.')
  }

  team2Clear(): void {
    if (this.team2.length == 0)
      return;
    this.lobby = this.lobby.concat(this.team2);
    this.sortLobby();
    this.team2 = [];
    this.addMessage('You cleared Team 2.')
  }

  team1Win(): void {
    if (this.team1.length == 8 && this.team2.length == 8)
      this.addMessage('You recorded a win for Team 1.')
  }

  team2Win(): void {
    if (this.team1.length == 8 && this.team2.length == 8)
      this.addMessage('You recorded a win for Team 2.')
  }
}
