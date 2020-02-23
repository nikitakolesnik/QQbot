import { Component } from '@angular/core';
import { IPlayer } from './player';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  lobby: IPlayer[] = [
    { name:     'Slam', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 17, 10) },
    { name:     'Yoko', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 17, 15) },
    { name: 'Candyboy', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 17, 23) },
    { name:    'Godly', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 17, 24) },
    { name:  'Santana', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 17, 56) },
    { name:    'Purif', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 18,  2) },
    { name:   'Chrona', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 18, 11) },
    { name:  'Butters', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 18, 47) },
    { name:      'Ice', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 18, 50) },
    { name:    'Lisek', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 18, 59) },
    { name:      'Oln', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 19, 30) },
    { name:    'Rainy', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 19, 54) },
    { name:   'Takida', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 20,  0) },
    { name:       'Jo', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 20, 29) },
    { name:   'Bounty', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 20, 30) },
    { name:   'Cracks', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 20, 44) },
    { name:   'Beware', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 21, 26) },
    { name:    'Jonas', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 21, 47) },
    { name:    'Dopos', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 22,  7) },
    { name:     'Hemo', /*picked: false,*/ position: null, joined: new Date(2020, 2, 23, 19, 23, 16) },
  ];
  team1: IPlayer[] = [];
  team2: IPlayer[] = [];
  history: string[] = [
    'Welcome!'
  ];

  constructor() { }

  ngOnInit(): void {
    this.setLobbyPlayerNumbers();
  }

  // UTILITY

  removeFromList(player: IPlayer, list: IPlayer[]) : void {
    var index = list.indexOf(player);
    list.splice(index, 1);
  }

  // PAGE FUNCTIONS

  sortLobby(): void {
    this.lobby.sort((a,b) => a.position - b.position);
  }

  setLobbyPlayerNumbers(): void {
    for (var i = 0; i < this.lobby.length; i++)
      this.lobby[i].position = i + 1;
  }

  addMessage(msg: string): void {
    if (this.history.length > 20)
      this.history.splice(0,1);
    this.history.push(msg);
  }

  removeFromLobby(player: IPlayer): void {
    this.removeFromList(player, this.lobby);
    this.setLobbyPlayerNumbers();
    this.addMessage('You removed ' + player.name + ' from the lobby.');
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
}
