function solve(arr) {
  class Grade {
    constructor(grade) {
      this.grade = grade;
      this.people = [];
    }

    addPerson(obj) {
      this.people.push(obj);
    }

    averageGrade() {
      return this.people.reduce((sum, person) => {
        sum += person["grade"];
        return sum;
      }, 0);
    }

    toString() {
      console.log(`${this.grade} Grade`);
      const names = this.people.reduce((names, person) => {
        names.push(person["name"]);
        return names;
      }, []);
      console.log(`List of students: ${names.join(", ")}`);
      console.log(
        `Average annual score from last year: ${(
          this.averageGrade() / this.people.length
        ).toFixed(2)}`
      );
    }
  }

  const grades = [];
  while (arr.length > 0) {
    const data = arr.shift().split(", ");
    const personInfo = {
      name: data[0].slice(14),
      grade: Number(data[2].slice(33)),
    };
    const grade = Number(data[1].slice(7)) + 1;
    if (personInfo["grade"] < 3) {
      continue;
    }
    let currGrade = grades.find((el) => el.grade === grade);

    if (!currGrade) {
      currGrade = new Grade(grade);
      grades.push(currGrade);
    }

    currGrade.addPerson(personInfo);
  }

  grades
    .sort((a, b) => a.grade - b.grade)
    .forEach((grade) => {
      grade.toString();
      console.log("");
    });
}

solve([
  "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
  "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
  "Student name: George, Grade: 8, Graduated with an average score: 2.83",
  "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
  "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
  "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
  "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
  "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
  "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
  "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
  "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
  "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00",
]);
solve([
  "Student name: George, Grade: 5, Graduated with an average score: 2.75",
  "Student name: Alex, Grade: 9, Graduated with an average score: 3.66",
  "Student name: Peter, Grade: 8, Graduated with an average score: 2.83",
  "Student name: Boby, Grade: 5, Graduated with an average score: 4.20",
  "Student name: John, Grade: 9, Graduated with an average score: 2.90",
  "Student name: Steven, Grade: 2, Graduated with an average score: 4.90",
  "Student name: Darsy, Grade: 1, Graduated with an average score: 5.15",
]);
