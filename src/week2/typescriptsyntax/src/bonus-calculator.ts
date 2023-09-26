
export function calculateBonusFor(balance: number, amount: number) {

    const now = new Date();
    const hour = now.getHours();
    const bonusMultiplier = hour >= 9 && hour < 17 ? .13 : .10;
    return balance >= 5000 ? amount * bonusMultiplier : 0;
}