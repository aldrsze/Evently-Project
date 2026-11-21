# How to Contribute

A short guide to working on **Evently-Project** with Git and GitHub.

**Rule #1:** Everyone works on their **own branch, named after themselves** (e.g. `juan`, `maria`). Nobody pushes directly to `main`.

## One-time setup

1. Install [Git](https://git-scm.com/downloads).
2. Make a [GitHub](https://github.com) account and ask the project owner to add you as a **collaborator**.
3. Tell Git who you are:

```bash
git config --global user.name "Your Name"
git config --global user.email "you@example.com"
```

4. Clone the project:

```bash
git clone https://github.com/aldrsze/evently-project.git
cd evently-project
```

5. Create your personal branch (use your own name, lowercase, no spaces):

```bash
git checkout -b yourname
git push -u origin yourname
```

You only do this once. From now on, `yourname` is your branch.

## The workflow (do this every time)

### 1. Switch to your branch and get the latest code

```bash
git checkout yourname
git pull origin main
```

### 2. Do your work

Edit files, then test that they actually run.

### 3. Save your changes (commit)

```bash
git add .
git commit -m "feat: add login page"
```

Write a short message saying **what** you did. See [Commit messages](#commit-messages) for the format.

### 4. Upload your branch

```bash
git push origin yourname
```

### 5. Open a Pull Request (PR)

1. Go to the repo on GitHub.
2. Click **Compare & pull request** (the yellow banner), or go to **Pull requests → New pull request**.
3. Set **base: `main`** and **compare: `yourname`**.
4. Write a short description of what you changed.
5. Click **Create pull request**.
6. Ask a teammate to review it, then **Merge**.

### 6. Stay up to date

After your PR is merged (or when teammates merge theirs), pull the latest into your branch before continuing:

```bash
git checkout yourname
git pull origin main
```

## Commit messages

Format: `type: subject`

| Type | Use for |
|---|---|
| `feat` | new feature |
| `fix` | bug fix |
| `docs` | docs only |
| `style` | CSS or formatting, no logic |
| `refactor` | same behavior, cleaner code |
| `chore` | config, packages, cleanup |

Rules: lowercase, no period, one line, say what changed.

```bash
git commit -m "feat: add staff login page"
git commit -m "fix: block double check-in on one ticket"
git commit -m "docs: add database steps to setup"
```

Good: `feat: add event delete button` — Bad: `updated stuff`

## Common situations

### A teammate merged into main

Happens most days. Get their work into your branch before you continue:

```bash
git checkout yourname
git pull origin main
```

If it says `Already up to date`, nothing changed. Otherwise push the merged result:

```bash
git push origin yourname
```

### main changed while you were working

You have your own commits and main has new ones. Git may open an editor for a merge message — save and close it.

```bash
git checkout yourname
git pull origin main
```

If it stops with conflicts, see [Merge conflicts](#merge-conflicts). Then:

```bash
git push origin yourname
```

### GitHub says "This branch has conflicts"

Fix it on your machine, not in the browser editor:

```bash
git checkout yourname
git pull origin main
```

Pick what to keep in each marked file, delete the `<<<<<<<`, `=======`, `>>>>>>>` lines, then:

```bash
git add .
git commit -m "chore: resolve merge conflict"
git push origin yourname
```

### Your pull request was merged

Your work is now on main. Bring main into your branch so your next pull request does not try to merge it again:

```bash
git checkout yourname
git pull origin main
```

### You forgot to pull before starting

Your branch is behind main. Pull now:

```bash
git checkout yourname
git pull origin main
```

If the pull refuses because you have uncommitted changes, commit or stash them first:

```bash
git stash
git pull origin main
git stash pop
```

### You committed on main by mistake

Do **not** push. Move the commits to your own branch, then put main back to what GitHub has:

```bash
git switch -c my-work
git switch main
git reset --hard origin/main
git switch yourname
git merge my-work
```

Ask the owner before you do this if you are not sure. `reset --hard` throws away uncommitted changes.

### Undo your last commit but keep the edits

```bash
git reset --soft HEAD~1
```

The files stay changed, and the commit is gone. Commit again with a better message.

### Someone changed `db\schema.sql`

Your database is now out of date and the app may crash with a missing column. Re-import the schema, but **you lose the rows**, so ask the team first:

```cmd
mysql -u root -p -e "DROP DATABASE evently_db"
mysql -u root -p -e "CREATE DATABASE evently_db"
mysql -u root -p evently_db < db\schema.sql
mysql -u root -p < db\seed.sql
```

## Before you open a pull request

- Your branch is `yourname`, not `main`.
- `dotnet build Evently.sln` succeeds.
- The app runs and you clicked the screen you changed.
- Commit messages look like `type: subject`.
- `git status` shows nothing you did not mean to change.
- No `db.config`, no `bin\`, no `obj\` in the commit.
- No commented-out code you forgot to delete.

## Rules

- Only work on your own branch.
- Always `git pull origin main` before you start working.
- Small commits, clear messages.
- Don't push straight to `main`.
- Read and understand code before committing it, especially if AI wrote it. If you can't explain it, don't submit it.

## Merge conflicts

Happens when two people edit the same lines. Don't panic:

```bash
git checkout yourname
git pull origin main
```

Git marks the conflicts in the file like this:

```
<<<<<<< HEAD
your version
=======
their version
>>>>>>> main
```

Pick what to keep, delete the marker lines, then:

```bash
git add .
git commit -m "chore: resolve merge conflict"
git push origin yourname
```

Still stuck? Ask the team before guessing.

## Cheat sheet

| Command | What it does |
|---|---|
| `git status` | See what changed |
| `git branch` | Show which branch you're on |
| `git checkout yourname` | Switch to your branch |
| `git pull origin main` | Get latest code from main |
| `git add .` | Stage all changes |
| `git commit -m "msg"` | Save changes locally |
| `git push origin yourname` | Upload your branch |
