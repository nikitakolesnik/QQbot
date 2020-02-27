import { Pipe, PipeTransform } from '@angular/core';
import { IPlayer } from './player';

@Pipe({
  name: 'teamfilter',
  pure: false
})
export class TeamPipe implements PipeTransform {
  transform(items: IPlayer[], team: number) {
    if (!items) {
      return items;
    }
    return items.filter(item => item.team == team);
  }
}
