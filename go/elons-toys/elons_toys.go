package elon

import (
	"fmt"
	"math"
)

// Drive Moves along the track updating the remaining battery and distance with the given
// batteryDrain and speed.
func (c *Car) Drive() {
	if c.batteryDrain <= c.battery {
		c.battery -= c.batteryDrain
		c.distance += c.speed
	}
}

// DisplayDistance returns distance.
func (c *Car) DisplayDistance() string {
	return fmt.Sprintf("Driven %d meters", c.distance)
}

// DisplayBattery returns battery percentage.
func (c *Car) DisplayBattery() string {
	return fmt.Sprintf("Battery at %d%%", c.battery)
}

// CanFinish Calculates if there is enough battery at the given speed to complete the track.
func (c *Car) CanFinish(trackDistance int) bool {
	runs := math.Ceil(float64(trackDistance) / float64(c.speed))
	batteryNeeded := c.battery - (c.batteryDrain * int(runs))
	return batteryNeeded >= 0
}
