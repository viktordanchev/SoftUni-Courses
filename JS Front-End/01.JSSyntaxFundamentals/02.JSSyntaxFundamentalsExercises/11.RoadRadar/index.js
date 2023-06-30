function determinesSpeedLimit(speed, area) {
  let speedLimit = "";

  switch (area) {
    case "motorway":
      speedLimit = 130;
      break;
    case "interstate":
      speedLimit = 90;
      break;
    case "city":
      speedLimit = 50;
      break;
    case "city":
      speedLimit = 50;
      break;
    default:
      speedLimit = 20;
      break;
  }

  if (speed <= speedLimit) {
    console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
  } else {
    let status = "";

    if (speed - speedLimit <= 20) {
      status = "speeding";
    } else if (speed - speedLimit <= 40) {
      status = "excessive speeding";
    } else {
      status = "reckless driving";
    }

    console.log(
      `The speed is ${
        speed - speedLimit
      } km/h faster than the allowed speed of ${speedLimit} - ${status}`
    );
  }
}

determinesSpeedLimit(40, "city");
