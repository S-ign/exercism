package logs

import (
	"strings"
)

// Application identifies the application emitting the given log.
func Application(log string) string {
	appMessage := map[string]string{
		"❗": "recommendation",
		"🔍": "search",
		"☀": "weather",
	}

	for _, r := range log {
		if val, ok := appMessage[string(r)]; ok {
			return val
		}
	}

	return "default"

}

// Replace replaces all occurrences of old with new, returning the modified log
// to the caller.
func Replace(log string, oldRune, newRune rune) string {
	return strings.ReplaceAll(log, string(oldRune), string(newRune))
}

// WithinLimit determines whether or not the number of characters in log is
// within the limit.
func WithinLimit(log string, limit int) bool {
	var l int
	for i := range log {
		l = i
	}
	return l < limit
}
