function printStudentInfo(studentName, studentAge, studentGrade) {
    const grade = studentGrade.toFixed(2);
    console.log(`Name: ${studentName}, Age: ${studentAge}, Grade: ${grade}`);
}

printStudentInfo('John', 15, 5.54678);