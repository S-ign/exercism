package sorting

import (
	"fmt"
	"strconv"
)

// DescribeNumber should return a string describing the number.
func DescribeNumber(f float64) string {
	return fmt.Sprintf("This is the number %.1f", f)
}

type NumberBox interface {
	Number() int
}

// DescribeNumberBox should return a string describing the NumberBox.
func DescribeNumberBox(nb NumberBox) string {
	return fmt.Sprintf("This is a box containing the number %.1f", float64(nb.Number()))
}

type FancyNumber struct {
	n string
}

func (i FancyNumber) Value() string {
	return i.n
}

type FancyNumberBox interface {
	Value() string
}

// ExtractFancyNumber should return the integer value for a FancyNumber
// and 0 if any other FancyNumberBox is supplied.
func ExtractFancyNumber(fnb FancyNumberBox) int {
	var i int
	fn, ok := fnb.(FancyNumber)
	if ok {
		// I don't have to check for error below because if err != nil we would want our int to be 0
		// Which it already is due to its zero value.
		i, _ = strconv.Atoi(fn.Value())
	}
	return i
}

// DescribeFancyNumberBox should return a string describing the FancyNumberBox.
func DescribeFancyNumberBox(fnb FancyNumberBox) string {
	return fmt.Sprintf("This is a fancy box containing the number %.1f", float64(ExtractFancyNumber(fnb)))
}

// DescribeAnything should return a string describing whatever it contains.
func DescribeAnything(i interface{}) string {
	switch a := i.(type) {
	case float64:
		return DescribeNumber(a)
	case int:
		return DescribeNumber(float64(a))
	case NumberBox:
		return DescribeNumberBox(a)
	case FancyNumberBox:
		return DescribeFancyNumberBox(a)
	default:
		return "Return to sender" // be gone with you
	}
}
