import { Component, OnInit } from '@angular/core';
import { TokenColor } from 'src/app/models/TokenColor';
import { TwoPersonService } from 'src/app/services/two-person.service';

@Component({
  selector: 'app-two-person',
  templateUrl: './two-person.component.html',
  styleUrls: ['./two-person.component.css']
})
export class TwoPersonComponent implements OnInit {
  first: string = "0";
  ai: string = "mini-max";
  started: boolean = false;
  board: TokenColor[][];
  done: boolean = false;
  winner: string;
  wait: boolean = false;
  constructor(private twoPersonService: TwoPersonService) { }

  ngOnInit() {
  }

  start() {
    this.board = [
      [TokenColor.Empty, TokenColor.Empty, TokenColor.Empty],
      [TokenColor.Empty, TokenColor.Empty, TokenColor.Empty],
      [TokenColor.Empty, TokenColor.Empty, TokenColor.Empty]
    ];
    this.started = true;
    this.done = false;
    this.winner = "";

    if (this.first == "1") {
      this.AIPlace();
    }
  }

  place(x: number, y: number) {
    if (this.board[x][y] != TokenColor.Green) {
      switch (this.board[x][y]) {
        case TokenColor.Empty:
          this.board[x][y] = TokenColor.Red;
          break;
        case TokenColor.Red:
          this.board[x][y] = TokenColor.Yellow;
          break;
        case TokenColor.Yellow:
          this.board[x][y] = TokenColor.Green;
          break;
      }
    }
  }

  PlayerPlace(x: number, y: number) {
    if (this.board[x][y] != TokenColor.Green) {
      this.place(x, y);

      if (this.gameWin()) {
        this.done = true;
        this.winner = "Player"
      }
      else {
        this.AIPlace();
      }
    }
  }

  AIPlace() {
    this.wait = true;
    this.twoPersonService.getNextStep(this.board, this.ai).subscribe(point => {
      console.log(point);
      this.place(point.x, point.y);

      if (this.gameWin()) {
        this.done = true;
        this.winner = "AI"
      }
      this.wait = false;
    });
  }

  color(x: number, y: number): string {
    switch (this.board[x][y]) {
      case TokenColor.Green:
        return "#09ad24";
      case TokenColor.Yellow:
        return "#f7e62d";
      case TokenColor.Red:
        return "#fa0707";
      default:
        return "none";
    }
  }

  gameWin(): boolean {
    for (let i = 0; i < this.board.length; i++) {
      if (
        this.board[i][0] != TokenColor.Empty && this.board[i][1] == this.board[i][0] && this.board[i][2] == this.board[i][0] ||
        this.board[0][i] != TokenColor.Empty && this.board[1][i] == this.board[0][i] && this.board[2][i] == this.board[0][i]
      ) {
        return true;
      }
    }
    if (
      this.board[0][0] != TokenColor.Empty && this.board[1][1] == this.board[0][0] && this.board[2][2] == this.board[0][0] ||
      this.board[0][2] != TokenColor.Empty && this.board[1][1] == this.board[0][2] && this.board[2][0] == this.board[0][2]
    ) {
      return true;
    }
    return false;
  }
}
