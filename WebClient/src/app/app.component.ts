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
  history: string[] = [];
  enum_roles = ['w', 'd', 'a', 'p', 'r', 'e', 'n', 'me', 'prot', 'heal', 'rt'];

  constructor() { }

  ngOnInit(): void {
    //this.setLobbyPlayerNumbers();
    var count = 1;
    //this.addToLobby({ name: 'Holye',     pos: count++, role: null, pref: ['w', 'd', 'a', 'p', 'r', 'e', 'n', 'me', 'prot', 'heal', 'rt'] });
    //this.addToLobby({ name: 'Yoko',     pos: count++, role: null, pref: ['w', 'd', 'p', 'e', 'n', 'me'] });
    //this.addToLobby({ name: 'Candyboy', pos: count++, role: null, pref: ['w', 'me'] });
    //this.addToLobby({ name: 'Godly',    pos: count++, role: null, pref: ['a'] });
    //this.addToLobby({ name: 'Santana',  pos: count++, role: null, pref: ['heal'] });
    //this.addToLobby({ name: 'Purif',    pos: count++, role: null, pref: ['me', 'prot', 'heal'] });
    //this.addToLobby({ name: 'Chrona',   pos: count++, role: null, pref: ['w', 'r', 'e', 'me'] });
    //this.addToLobby({ name: 'Butters',  pos: count++, role: null, pref: ['w', 'd', 'e'] });
    //this.addToLobby({ name: 'Ice',      pos: count++, role: null, pref: ['w', 'heal'] });
    //this.addToLobby({ name: 'Lisek',    pos: count++, role: null, pref: ['r', 'me'] });
    //this.addToLobby({ name: 'Oln',      pos: count++, role: null, pref: ['heal'] });
    //this.addToLobby({ name: 'Rainy',    pos: count++, role: null, pref: ['prot'] });
    //this.addToLobby({ name: 'Takida',   pos: count++, role: null, pref: ['w'] });
    //this.addToLobby({ name: 'Jo',       pos: count++, role: null, pref: ['e'] });
    //this.addToLobby({ name: 'Bounty',   pos: count++, role: null, pref: ['w', 'p', 'me'] });
    //this.addToLobby({ name: 'Cracks',   pos: count++, role: null, pref: ['w'] });
    //this.addToLobby({ name: 'Beware',   pos: count++, role: null, pref: ['prot'] });
    //this.addToLobby({ name: 'Jonas',    pos: count++, role: null, pref: ['w', 'prot'] });
    //this.addToLobby({ name: 'Dopos',    pos: count++, role: null, pref: ['r', 'me'] });
    //this.addToLobby({ name: 'Hemo',     pos: count++, role: null, pref: ['w', 'd'] });
    this.addToLobby({ name: 'Slam', pos: count++, role: null, pref: ['w'] });
    this.addToLobby({ name: 'Candy', pos: count++, role: null, pref: ['w', 'me'] });
    this.addToLobby({ name: 'Yoko', pos: count++, role: null, pref: ['w', 'd', 'p', 'e', 'me'] });
    this.addToLobby({ name: 'Takida', pos: count++, role: null, pref: ['w'] });
    this.addToLobby({ name: 'Bounty', pos: count++, role: null, pref: ['w', 'p', 'me', 'prot'] });
    this.addToLobby({ name: 'Godly', pos: count++, role: null, pref: ['me'] });
    this.addToLobby({ name: 'Hemo', pos: count++, role: null, pref: ['w', 'd', 'me'] });
    this.addToLobby({ name: 'Martin', pos: count++, role: null, pref: ['heal', 'prot'] });
    this.addToLobby({ name: 'Dopos', pos: count++, role: null, pref: ['r', 'me'] });
    this.addToLobby({ name: 'Rainy', pos: count++, role: null, pref: ['prot'] });
    this.addToLobby({ name: 'Holye', pos: count++, role: null, pref: ['d', 'e', 'heal'] });
    this.addToLobby({ name: 'Yoshi', pos: count++, role: null, pref: ['prot'] });
    this.addToLobby({ name: 'Oln', pos: count++, role: null, pref: ['heal'] });
    this.addToLobby({ name: 'Santana', pos: count++, role: null, pref: ['heal'] });
    this.addToLobby({ name: 'Beware', pos: count++, role: null, pref: ['prot'] });
    this.addToLobby({ name: 'Purif', pos: count++, role: null, pref: ['me', 'prot', 'heal'] });
    this.addToLobby({ name: 'Ice', pos: count++, role: null, pref: ['w', 'heal'] });
    this.addToLobby({ name: 'Cracks', pos: count++, role: null, pref: ['w'] });
    this.addToLobby({ name: 'Butters', pos: count++, role: null, pref: ['w', 'd', 'e', 'me'] });
    this.addToLobby({ name: 'Roken', pos: count++, role: null, pref: ['w'] });
  }

  // UTILITY

  removeFromList(player: IPlayer, list: IPlayer[]) : void {
    var index = list.indexOf(player);
    list.splice(index, 1);
  }

  // PAGE FUNCTIONS

  setRole(player: IPlayer, role: string, team: number): void {
    console.log('player: ' + player.name + ', team: ' + team);
    if (team == 1) {
      var index = this.team1.indexOf(player);
      this.team1[index].role = role;
    }
    else if (team == 2) {
      var index = this.team2.indexOf(player);
      this.team2[index].role = role;
    }
  }

  sortLobby(): void {
    this.lobby.sort((a,b) => a.pos - b.pos);
  }

  //setLobbyPlayerNumbers(): void {
  //  for (var i = 0; i < this.lobby.length; i++)
  //    this.lobby[i].pos = i + 1;
  //}

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
    //this.setLobbyPlayerNumbers();
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
