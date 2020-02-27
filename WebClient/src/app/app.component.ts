import { Component } from '@angular/core';
import { IPlayer } from './player';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  lobby:     IPlayer[] = [];
  history:   string[]  = [];
  teamCount: number[]  = [0, 0, 0];

  constructor() { }

  ngOnInit(): void {
    this.addToLobby({name: 'Holye'});
    this.addToLobby({name: 'Yoko'});
    this.addToLobby({name: 'Candyboy'});
    this.addToLobby({name: 'Godly'});
    this.addToLobby({name: 'Santana'});
    this.addToLobby({name: 'Purif'});
    this.addToLobby({name: 'Chrona'});
    this.addToLobby({name: 'Butters'});
    this.addToLobby({name: 'Ice'});
    this.addToLobby({name: 'Lisek'});
    this.addToLobby({name: 'Oln'});
    this.addToLobby({name: 'Rainy'});
    this.addToLobby({name: 'Takida'});
    this.addToLobby({name: 'Jo'});
    this.addToLobby({name: 'Bounty'});
    this.addToLobby({name: 'Cracks'});
    this.addToLobby({name: 'Beware'});
    this.addToLobby({name: 'Jonas'});
    this.addToLobby({name: 'Dopos'});
    this.addToLobby({name: 'Hemo'});
  }

  addMessage(msg: string): void {
    if (this.history.length >= 22)
      this.history.pop();
    this.history.unshift('[' + new Date().toLocaleTimeString() + '] ' + msg);
  }


  // LOBBY

  numberLobby(): void {
    for (var i = 0; i < this.lobby.length; i++)
      this.lobby[i].pos = i + 1;
  }

  addToLobby(player: IPlayer): void {
    player.team = 0;
    player.pos = this.lobby.length + 1;
    this.lobby.push(player);
    this.addMessage(player.name + ' joined.');
  }

  removeFromLobby(player: IPlayer): void {
    this.lobby.splice(this.lobby.indexOf(player), 1);
    this.addMessage('You kicked ' + player.name + '.');
    this.numberLobby();
  }


  // TEAM

  setTeam(player: IPlayer, team: number): void {
    if (this.teamCount[team] == 8) return;
    this.teamCount[team]++;
    var message = 'You ' + (player.team == 0 ? 'added ' : 'moved ') + player.name + ' to Team ' + team;
    this.lobby[this.lobby.indexOf(player)].team = team;
    this.addMessage(message);
  }

  setNoTeam(player: IPlayer): void {
    this.teamCount[player.team]--;
    var message = 'You removed ' + player.name + ' from Team ' + player.team + '.';
    this.lobby[this.lobby.indexOf(player)].team = 0;
    this.addMessage(message);
  }

  teamClear(team: number): void {
    this.teamCount[team] = 0;
    this.lobby.forEach(function (player) { if (player.team == team) player.team = 0; });
    this.addMessage('You cleared Team ' + team + '.')
  }


  // RESULT

  teamWin(team: number): void {
    if (this.teamCount[1] == 8 && this.teamCount[2] == 8)
      this.addMessage('You recorded a win for Team ' + team + '.')
  }
}
