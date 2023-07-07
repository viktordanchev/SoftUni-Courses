function manageAppointments(arr) {
  const meetings = {};
  for (let index = 0; index < arr.length; index++) {
    const [weekday, name] = arr[index].split(" ");

    if (meetings.hasOwnProperty(weekday)) {
      console.log(`Conflict on ${weekday}!`);
    } else {
      meetings[weekday] = name;
      console.log(`Scheduled for ${weekday}`);
    }
  }

  for (const key in meetings) {
    console.log(`${key} -> ${meetings[key]}`);
  }
}

manageAppointments([
  "Monday Peter",
  "Wednesday Bill",
  "Monday Tim",
  "Friday Tim",
]);
manageAppointments([
  "Friday Bob",
  "Saturday Ted",
  "Monday Bill",
  "Monday John",
  "Wednesday George",
]);
